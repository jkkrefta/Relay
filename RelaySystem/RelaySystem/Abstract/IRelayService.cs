using RelaySystem.Models;

namespace RelaySystem.Abstract
{
    public interface IRelayService
    {
        int LinkCount { get; }
        void AddLink(IChannel link);
        void RelayMessage(Message message);
    }
}