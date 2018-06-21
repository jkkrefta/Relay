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
