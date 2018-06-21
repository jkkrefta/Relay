using System;
using System.Collections.Generic;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.Services
{
    public class RelayService : IRelayService
    {
        private readonly List<IChannel> _relayLinks = new List<IChannel>();
        public int LinkCount => _relayLinks.Count;

        public void AddLink(IChannel link)
        {
            _relayLinks.Add(link);
        }

        public void RelayMessage(Message message)
        {
            ValidateThatThereAreLinks();
            _relayLinks.ForEach(link => link.EnqueueMessage(message));
        }

        private void ValidateThatThereAreLinks()
        {
            if (LinkCount == 0)
            {
                throw new InvalidOperationException("No Subscriber avilable. Cannot relay message!");
            }
        }
    }
}
