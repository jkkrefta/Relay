using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.Channels
{
    class BinaryChannel : IChannel
    {
        internal readonly ConcurrentQueue<Message> Queue; // is internal for test porpouses - ugly hack - with more time would make it properly
        private readonly ISubscriber _subscriber;
        private readonly RetryPolicy<bool> _retryPolicy;
        private Task _sendMessageTask;

        public BinaryChannel(ISubscriber subscriber)
        {
            _subscriber = subscriber;
            Queue = new ConcurrentQueue<Message>();
            _retryPolicy = Policy.HandleResult(false).WaitAndRetryForever(retryAttempt =>
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public void EnqueueMessage(Message message)
        {
            Queue.Enqueue(message);

            if (_sendMessageTask != null && TaskIsRunning()) {return;}

            _sendMessageTask = BuildMessageTaskChain();
            _sendMessageTask.Start();
        }

        internal void SendMessage(Message message)
        {
            _retryPolicy.Execute(() => _subscriber.ReciveMessage(message).Result);
        }

        internal Task BuildMessageTaskChain()
        {
            Queue.TryDequeue(out var initialMessage);
            var initialTask = new Task(() => SendMessage(initialMessage));
            QueueMoreMessageTasks(initialTask).ContinueWith(QueueMoreMessageTasks);
            return initialTask;
        }

        private Task QueueMoreMessageTasks(Task initialTask)
        {
            var currentTask = initialTask;
            while (!Queue.IsEmpty)
            {
                Queue.TryDequeue(out var message);
                currentTask = currentTask.ContinueWith(t => SendMessage(message));
            }
            return currentTask;
        }

        private bool TaskIsRunning()
        {
            return _sendMessageTask.Status != TaskStatus.RanToCompletion &&
                   _sendMessageTask.Status != TaskStatus.Canceled;
        }
    }
}
