namespace RelaySystem.Abstract
{
    public interface ISubscriberService
    {
        void Subscribe(ISubscriber subscriber);
        void Subscribe(IRemoteService subscriber);
    }
}