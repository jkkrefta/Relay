using System;
using FakeItEasy;
using NUnit.Framework;
using RelaySystem.Abstract;
using RelaySystem.Models;
using RelaySystem.Services;

namespace RelaySystem.Tests.Services
{
    class DispatcherServiceTests
    {
        private DispatcherService _dispatcherService;
        private readonly Message _emptyMessage = new Message();

        [SetUp]
        public void Setup()
        {
            _dispatcherService = new DispatcherService();
        }

        [Test]
        public void DispatchMessage_WhenThereIsNoChannelsRegistered_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => _dispatcherService.DispatchMessage(_emptyMessage));
        }

        [Test]
        public void DispatchMessage_CallsEnqueueMessageOnSubscribedChannels()
        {
            var relayLink = A.Fake<IChannel>();
            _dispatcherService.AddChannel(relayLink);
            _dispatcherService.DispatchMessage(_emptyMessage);
            A.CallTo(() => relayLink.EnqueueMessage(_emptyMessage)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void AddLink_IRelayLink_AddsItToRelayLinks()
        {
            _dispatcherService.AddChannel(A.Fake<IChannel>());
            Assert.That(_dispatcherService.ChannelCount, Is.EqualTo(1));
        }
    }
}
