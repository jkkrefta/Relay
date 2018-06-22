using System;
using RelaySystem.Abstract;

namespace RelaySystem.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IChannelFactory _channelFactory;
        private readonly IDispatcherService _dispatcherService;

        public SubscriberService(IChannelFactory channelFactory, IDispatcherService dispatcherService)
        {
            _channelFactory = channelFactory;
            _dispatcherService = dispatcherService;
        }

        public void Subscribe(ISubscriber subscriber)
        {
            SubscriberIsNotNull(subscriber);
            var channel = _channelFactory.CreateBinaryChannel(subscriber);
            _dispatcherService.AddChannel(channel);
        }

        public void Subscribe(IRemoteService subscriber)
        {
            SubscriberIsNotNull(subscriber);
            var relayLink = _channelFactory.CreateHttpChannel(subscriber);
            _dispatcherService.AddChannel(relayLink);
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
