using RelaySystem.Models;

namespace RelaySystem.Abstract
{
    public interface IRelayService
    {
        int LinkCount { get; }
        void AddLink(IRelayLink link);
        void RelayMessage(Message message);
    }
}