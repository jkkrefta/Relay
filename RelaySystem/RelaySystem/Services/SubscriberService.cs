using RelaySystem.Abstract;

namespace RelaySystem.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IRelayLinkFactory _relayLinkFactory;
        private readonly IRelayService _relayService;

        public SubscriberService(IRelayLinkFactory relayLinkFactory, IRelayService relayService)
        {
            _relayLinkFactory = relayLinkFactory;
            _relayService = relayService;
        }

        public void Subscribe(ISubscriber subscriber)
        {
            var relayLink = _relayLinkFactory.Create(subscriber);
            _relayService.AddLink(relayLink);
        }

        public void Subscribe(IRemoteService subscriber)
        {
            var relayLink = _relayLinkFactory.Create(subscriber);
            _relayService.AddLink(relayLink);
        }
    }
}
