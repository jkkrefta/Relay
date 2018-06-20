using FakeItEasy;
using NUnit.Framework;
using RelaySystem.Abstract;
using RelaySystem.Factories;
using RelaySystem.Services;

namespace RelaySystem.Tests.Factories
{
    class RelayLinkFactoryTests
    {
        private RelayLinkFactory _relayLinkFactory;

        [SetUp]
        public void Setup()
        {
            _relayLinkFactory = new RelayLinkFactory();
        }

        [Test]
        public void Create_GivenISubscriber_ReturnsBinaryRelayLink()
        {
            var relayLink = _relayLinkFactory.Create(A.Fake<ISubscriber>());
            Assert.That(relayLink, Is.TypeOf<BinaryRelayLink>());
        }

        [Test]
        public void Create_GivenIRemoteService_ReturnsHttpRelayLink()
        {
            var relayLink = _relayLinkFactory.Create(A.Fake<IRemoteService>());
            Assert.That(relayLink, Is.TypeOf<HttpRelayLink>());
        }
    }
}