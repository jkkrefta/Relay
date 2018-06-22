using RelaySystem.Abstract;
using RelaySystem.Factories;
using RelaySystem.Models;
using RelaySystem.Services;

namespace RelaySystem
{
    public class Relay : IRelay
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IDispatcherService _dispatcherService;

        public Relay()
        {
            _dispatcherService = new DispatcherService();
            _subscriberService = new SubscriberService(new ChannelFactory(), _dispatcherService);
        }

        public void Subscribe(ISubscriber subscriber)
        {
            _subscriberService.Subscribe(subscriber);
        }

        public void Subscribe(IRemoteService remoteService)
        {
            _subscriberService.Subscribe(remoteService);
        }

        public void SendMessage(Message message)
        {
            _dispatcherService.DispatchMessage(message);
        }
    }
}
