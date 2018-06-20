using System.Collections.Concurrent;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.Services
{
    public class BinaryRelayLink : IRelayLink
    {
        private readonly ISubscriber _subscriber;
        private readonly ConcurrentQueue<Message> _queue;

        public BinaryRelayLink(ISubscriber subscriber)
        {
            _subscriber = subscriber;
            _queue = new ConcurrentQueue<Message>();
        }

        public void EnqueueMessage(Message message)
        {
            _queue.Enqueue(message);
        }

        public void SendMessage()
        {
            _queue.TryDequeue(out var message);
            _subscriber.ReciveMessage(message);
        }
    }
}
