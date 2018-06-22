using RelaySystem.Models;

namespace RelaySystem.Abstract
{
    public interface IRelay
    {
        void Subscribe(ISubscriber subscriber);
        void Subscribe(IRemoteService remoteService);
        void SendMessage(Message message);
    }
}