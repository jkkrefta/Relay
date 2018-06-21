using RelaySystem.Models;

namespace RelaySystem.Abstract
{
    public interface IChannel
    {
        void EnqueueMessage(Message message);
    }
}
