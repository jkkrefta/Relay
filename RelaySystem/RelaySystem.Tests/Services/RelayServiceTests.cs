using System;
using FakeItEasy;
using NUnit.Framework;
using RelaySystem.Abstract;
using RelaySystem.Models;
using RelaySystem.Services;

namespace RelaySystem.Tests.Services
{
    class RelayServiceTests
    {
        private RelayService _relayService;
        private readonly Message _emptyMessage = new Message();

        [SetUp]
        public void Setup()
        {
            _relayService = new RelayService();
        }

        [Test]
        public void RelayMessage_GivenNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _relayService.RelayMessage(null));
        }

        [Test]
        public void RelayMessage_WhenThereIsNoRelayLink_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => _relayService.RelayMessage(_emptyMessage));
        }

        [Test]
        public void RelayMessage_CallsEnqueueMessageOnAllLinks()
        {
            var relayLink = A.Fake<IRelayLink>();
            _relayService.AddLink(relayLink);
            _relayService.RelayMessage(_emptyMessage);
            A.CallTo(() => relayLink.EnqueueMessage(_emptyMessage)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void AddLink_IRelayLink_AddsItToRelayLinks()
        {
            _relayService.AddLink(A.Fake<IRelayLink>());
            Assert.That(_relayService.LinkCount, Is.EqualTo(1));
        }
    }
}
