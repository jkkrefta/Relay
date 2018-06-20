namespace RelaySystem.Abstract
{
    public interface IRelayLinkFactory
    {
        IRelayLink Create(ISubscriber subscriber);
        IRelayLink Create(IRemoteService subscriber);
    }
}