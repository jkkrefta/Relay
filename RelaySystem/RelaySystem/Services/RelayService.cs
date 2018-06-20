using System;
using System.Collections.Generic;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.Services
{
    public class RelayService : IRelayService
    {
        private readonly List<IRelayLink> _relayLinks = new List<IRelayLink>();
        public int LinkCount => _relayLinks.Count;

        public void AddLink(IRelayLink link)
        {
            _relayLinks.Add(link);
        }

        public void RelayMessage(Message message)
        {
            ValidateThatMessageIsNotNull(message);
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

        private static void ValidateThatMessageIsNotNull(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
        }
    }
}
