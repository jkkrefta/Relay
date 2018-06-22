using FakeItEasy;
using NUnit.Framework;
using RelaySystem.Abstract;
using RelaySystem.Channels;
using RelaySystem.Factories;
using RelaySystem.Services;

namespace RelaySystem.Tests.Factories
{
    class RelayLinkFactoryTests
    {
        private ChannelFactory _channelFactory;

        [SetUp]
        public void Setup()
        {
            _channelFactory = new ChannelFactory();
        }

        [Test]
        public void Create_GivenISubscriber_ReturnsBinaryRelayLink()
        {
            var relayLink = _channelFactory.CreateBinaryChannel(A.Fake<ISubscriber>());
            Assert.That(relayLink, Is.TypeOf<BinaryChannel>());
        }

        [Test]
        public void Create_GivenIRemoteService_ReturnsHttpRelayLink()
        {
            var relayLink = _channelFactory.CreateHttpChannel(A.Fake<IRemoteService>());
            Assert.That(relayLink, Is.TypeOf<HttpChannel>());
        }
    }
}