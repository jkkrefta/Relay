using RelaySystem.Models;

namespace RelaySystem.Abstract
{
    public interface IDispatcherService
    {
        int ChannelCount { get; }
        void AddChannel(IChannel channel);
        void DispatchMessage(Message message);
    }
}