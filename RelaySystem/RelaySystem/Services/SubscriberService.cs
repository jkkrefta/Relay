using System;
using RelaySystem.Abstract;

namespace RelaySystem.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IChannelFactory _channelFactory;
        private readonly IRelayService _relayService;

        public SubscriberService(IChannelFactory channelFactory, IRelayService relayService)
        {
            _channelFactory = channelFactory;
            _relayService = relayService;
        }

        public void Subscribe(ISubscriber subscriber)
        {
            SubscriberIsNotNull(subscriber);
            var relayLink = _channelFactory.CreateBinaryChannel(subscriber);
            _relayService.AddLink(relayLink);
        }

        public void Subscribe(IRemoteService subscriber)
        {
            SubscriberIsNotNull(subscriber);
            var relayLink = _channelFactory.CreateHttpChannel(subscriber);
            _relayService.AddLink(relayLink);
        }

        private void SubscriberIsNotNull<T>(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }
}
