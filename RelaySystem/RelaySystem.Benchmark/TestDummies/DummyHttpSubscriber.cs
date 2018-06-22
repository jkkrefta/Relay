using System.Net;
using System.Threading.Tasks;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.Benchmark.TestDummies
{
    public class DummyHttpSubscriber : IRemoteService
    {
        public Task<HttpStatusCode> ReciveMessage(Message msg)
        {
            return Task.FromResult(HttpStatusCode.Accepted);
        }
    }
}