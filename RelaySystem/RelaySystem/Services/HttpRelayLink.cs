using System.Collections.Concurrent;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.Services
{
    public class HttpRelayLink : IRelayLink
    {
        private readonly IRemoteService _subscriber;
        private readonly ConcurrentQueue<Message> _queue;

        public HttpRelayLink(IRemoteService subscriber)
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
