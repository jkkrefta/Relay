using System;
using System.Collections.Generic;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.Services
{
    public class DispatcherService : IDispatcherService
    {
        private readonly List<IChannel> _channels = new List<IChannel>();
        public int ChannelCount => _channels.Count;

        public void AddChannel(IChannel channel)
        {
            _channels.Add(channel);
        }

        public void DispatchMessage(Message message)
        {
            ValidateThatThereThereAreChannels();
            _channels.ForEach(link => link.EnqueueMessage(message));
        }

        private void ValidateThatThereThereAreChannels()
        {
            if (ChannelCount == 0)
            {
                throw new InvalidOperationException("No Subscriber avilable. Cannot relay message!");
            }
        }
    }
}
