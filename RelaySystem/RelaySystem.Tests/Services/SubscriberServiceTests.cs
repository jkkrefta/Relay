using FakeItEasy;
using NUnit.Framework;
using RelaySystem.Abstract;
using RelaySystem.Services;

namespace RelaySystem.Tests.Services
{
    class SubscriberServiceTests
    {
        private SubscriberService _subscriberService;
        private IRelayService _relayService;

        [SetUp]
        public void Setup()
        {
            _relayService = A.Fake<IRelayService>();
            _subscriberService = new SubscriberService(A.Fake<IRelayLinkFactory>(), _relayService);
        }

        [Test]
        public void Subscribe_GivenISubscriber_AddsRelayLinkToRelayService()
        {
            _subscriberService.Subscribe(A.Fake<ISubscriber>());
            A.CallTo(() => _relayService.AddLink(A<IRelayLink>._)).MustHaveHappenedOnceExactly();
        }
    }
}
