using FakeItEasy;
using NUnit.Framework;
using RelaySystem.Abstract;
using RelaySystem.Channels;
using RelaySystem.Models;

namespace RelaySystem.Tests.Channels
{
    public class HttpChannelTests
    {
        private IRemoteService _remoteService;
        private HttpChannel _httpChannel;
        private Message _message;

        [SetUp]
        public void Setup()
        {
            _remoteService = A.Fake<IRemoteService>();
            _httpChannel = new HttpChannel(_remoteService);
            _message = new Message();
        }
    }
}
