using RelaySystem.Models;

namespace RelaySystem.Abstract
{
    internal interface IDispatcherService
    {
        int ChannelCount { get; }
        void AddChannel(IChannel channel);
        void DispatchMessage(Message message);
    }
}