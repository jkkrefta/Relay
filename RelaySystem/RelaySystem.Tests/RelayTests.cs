using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RelaySystem.Models;

namespace RelaySystem.Tests
{
    public class RelayTests
    {
        private Relay _relay;
        private readonly Message _emptyMessage = new Message();

        [SetUp]
        public void Setup()
        {
            _relay = new Relay();
        }

        [Test]
        public void RelayMessage_GivenNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _relay.RelayMessage(null));
        }

        [Test]
        public void RelayMessage_GivenMessage_ReturnsTask()
        {
            var result = _relay.RelayMessage(_emptyMessage);
            Assert.That(result, Is.TypeOf<Task<bool>>());
        }
    }
}
