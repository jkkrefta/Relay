using RelaySystem.Abstract;
using RelaySystem.Services;

namespace RelaySystem.Factories
{
    public class ChannelFactory : IChannelFactory
    {
        public IChannel CreateBinaryChannel(ISubscriber subscriber)
        {
            return new BinaryChannel(subscriber);
        }

        public IChannel CreateHttpChannel(IRemoteService subscriber)
        {
            return new HttpChannel(subscriber);
        }
    }
}
