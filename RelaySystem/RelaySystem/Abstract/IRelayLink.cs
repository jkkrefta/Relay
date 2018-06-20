using RelaySystem.Models;

namespace RelaySystem.Abstract
{
    public interface IRelayLink
    {
        void EnqueueMessage(Message message);
        void SendMessage();
    }
}
