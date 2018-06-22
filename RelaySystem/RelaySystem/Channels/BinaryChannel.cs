using System;
using System.Collections.Generic;
using System.ComponentModel;
using Polly;
using Polly.Retry;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.Channels
{
    class BinaryChannel : IChannel, IDisposable
    {
        private readonly ISubscriber _subscriber;
        private readonly Queue<Message> _queue;
        private readonly BackgroundWorker _backgroundWorker;
        private readonly RetryPolicy<bool> _retryPolicy;

        public BinaryChannel(ISubscriber subscriber)
        {
            _subscriber = subscriber;
            _queue = new Queue<Message>();
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += SendMessage;
            _backgroundWorker.RunWorkerCompleted += SendMessageCompleted;
            _retryPolicy = Policy.HandleResult(false).WaitAndRetryForever(retryAttempt =>
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public void Dispose()
        {
            _backgroundWorker?.Dispose();
        }

        public void EnqueueMessage(Message message)
        {
            _queue.Enqueue(message);
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }

        private void SendMessage(object sender, EventArgs e)
        {
            var message = _queue.Dequeue();
            _retryPolicy.Execute(() => _subscriber.ReciveMessage(message).Result);
        }

        private void SendMessageCompleted(object sender, EventArgs e)
        {
            if (_queue.Count > 0)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }
    }
}
