using System.Collections.Generic;
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
        public void SendMessage_WhenWorkerIsNotBusy_ShouldInvokeReciveMessage()
        {
            A.CallTo(() => _subscriber.ReciveMessage(_message)).Returns(true);

            _binaryChannel.SendMessage(_message);

            A.CallTo(() => _subscriber.ReciveMessage(_message)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void MessaggingMechanism_GivenQueueOf3Messages_ShouldInvokeReciveMessage_3Times()
        {
            A.CallTo(() => _subscriber.ReciveMessage(A<Message>._)).Returns(true);
            _binaryChannel.Queue.Enqueue(_message);
            _binaryChannel.Queue.Enqueue(_message);
            _binaryChannel.Queue.Enqueue(_message);

            _binaryChannel.BuildMessageTaskChain().RunSynchronously();

            A.CallTo(() => _subscriber.ReciveMessage(_message)).MustHaveHappened(3, Times.Exactly);
        }

        [Test]
        public void MessaggingMechanism_GivenQueueOf3Messages_ShouldDeliverMessagesInRightOrder()
        {
            var recivedMessages = new List<Message>();
            A.CallTo(() => _subscriber.ReciveMessage(A<Message>._))
                .Invokes(call => recivedMessages.Add((Message)call.Arguments[0])).Returns(true);
            _binaryChannel.Queue.Enqueue(new Message { Data = "1" });
            _binaryChannel.Queue.Enqueue(new Message { Data = "2" });
            _binaryChannel.Queue.Enqueue(new Message { Data = "3" });

            _binaryChannel.BuildMessageTaskChain().RunSynchronously();

            Assert.That(recivedMessages[0].Data, Is.EqualTo("1"));
            Assert.That(recivedMessages[1].Data, Is.EqualTo("2"));
            Assert.That(recivedMessages[2].Data, Is.EqualTo("3"));
        }
    }
}