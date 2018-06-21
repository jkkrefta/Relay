using System;
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
            _subscriberService = new SubscriberService(A.Fake<IChannelFactory>(), _relayService);
        }

        [Test]
        public void Subscribe_GivenNullIRemoteService_Throws() => Assert.Throws<ArgumentNullException>(() => _subscriberService.Subscribe((IRemoteService) null));

        [Test]
        public void Subscribe_GivenNullISubscriber_Throws() => Assert.Throws<ArgumentNullException>(() => _subscriberService.Subscribe((ISubscriber)null));

        [Test]
        public void Subscribe_GivenISubscriber_AddsRelayLinkToRelayService()
        {
            _subscriberService.Subscribe(A.Fake<ISubscriber>());
            A.CallTo(() => _relayService.AddLink(A<IChannel>._)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Subscribe_GivenIRemoteService_AddsRelayLinkToRelayService()
        {
            _subscriberService.Subscribe(A.Fake<IRemoteService>());
            A.CallTo(() => _relayService.AddLink(A<IChannel>._)).MustHaveHappenedOnceExactly();
        }
    }
}
