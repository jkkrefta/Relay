using FakeItEasy;
using NUnit.Framework;
using RelaySystem.Abstract;
using RelaySystem.Models;
using RelaySystem.Services;

namespace RelaySystem.Tests.Services
{
    public class HttpRelayLinkTests
    {
        private IRemoteService _remoteService;
        private HttpRelayLink _httpRelayLink;
        private Message _message;

        [SetUp]
        public void Setup()
        {
            _remoteService = A.Fake<IRemoteService>();
            _httpRelayLink = new HttpRelayLink(_remoteService);
            _message = new Message();
        }

        [Test]
        public void SendMessage_CallsRemoteServiceReviceMessage()
        {
            _httpRelayLink.EnqueueMessage(_message);
            _httpRelayLink.SendMessage();
            A.CallTo(() => _remoteService.ReciveMessage(_message)).MustHaveHappenedOnceExactly();
        }
    }
}
