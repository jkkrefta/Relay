namespace RelaySystem.Abstract
{
    internal interface ISubscriberService
    {
        void Subscribe(ISubscriber subscriber);
        void Subscribe(IRemoteService subscriber);
    }
}