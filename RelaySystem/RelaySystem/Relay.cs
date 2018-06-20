using System;
using System.Threading.Tasks;
using RelaySystem.Models;

namespace RelaySystem
{
    public class Relay
    {
        public Task<bool> RelayMessage(Message message)
        {
            ValidateThatMessageIsNotNull(message);
            return Task.FromResult(true);
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
