using RelaySystem.Abstract;
using RelaySystem.Services;

namespace RelaySystem.Factories
{
    public class RelayLinkFactory : IRelayLinkFactory
    {
        public IRelayLink Create(ISubscriber subscriber)
        {
            return new BinaryRelayLink(subscriber);
        }

        public IRelayLink Create(IRemoteService subscriber)
        {
            return new HttpRelayLink(subscriber);
        }
    }
}
