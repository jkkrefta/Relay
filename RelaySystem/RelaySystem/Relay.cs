using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem
{
    public class Relay : IRelay
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IDispatcherService _dispatcherService;

        public Relay(ISubscriberService subscriberService, IDispatcherService dispatcherService)
        {
            _subscriberService = subscriberService;
            _dispatcherService = dispatcherService;
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
