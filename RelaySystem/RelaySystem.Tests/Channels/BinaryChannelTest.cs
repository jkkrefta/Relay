using FakeItEasy;
using NUnit.Framework;
using RelaySystem.Abstract;
using RelaySystem.Channels;
using RelaySystem.Models;

namespace RelaySystem.Tests.Channels
{
    public class BinaryChannelTest
    {
        private ISubscriber _subscriber;
        private BinaryChannel _binaryChannel;
        private Message _message;

        [SetUp]
        public void Setup()
        {
            _subscriber = A.Fake<ISubscriber>();
            _binaryChannel = new BinaryChannel(_subscriber);
            _message = new Message();
        }

        [Test]
        public void EnqueueMessage_WhenWorkerIsNotBusy_ShouldInvoke()
        {
            _binaryChannel.EnqueueMessage(_message);
            A.CallTo(_subscriber.ReciveMessage(A<Message>._)).MustHaveHappenedOnceExactly();
        }
    }
}