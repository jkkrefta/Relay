using FakeItEasy;
using NUnit.Framework;
using RelaySystem.Abstract;
using RelaySystem.Models;
using RelaySystem.Services;

namespace RelaySystem.Tests.Services
{
    public class BinaryRelayLinkTests
    {
        private ISubscriber _subscriber;
        private BinaryRelayLink _binaryRelayLink;
        private Message _message;

        [SetUp]
        public void Setup()
        {
            _subscriber = A.Fake<ISubscriber>();
            _binaryRelayLink = new BinaryRelayLink(_subscriber);
            _message = new Message();
        }

        [Test]
        public void SendMessage_CallsSubscriberReviceMessage()
        {
            _binaryRelayLink.EnqueueMessage(_message);
            _binaryRelayLink.SendMessage();
            A.CallTo(() => _subscriber.ReciveMessage(_message)).MustHaveHappenedOnceExactly();
        }
    }
}