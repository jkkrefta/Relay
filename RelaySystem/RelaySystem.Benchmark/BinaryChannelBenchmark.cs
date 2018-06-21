using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using RelaySystem.Factories;
using RelaySystem.Models;
using RelaySystem.Services;

namespace RelaySystem.Benchmark
{
    [CoreJob]
    public class BinaryChannelBenchmark
    {
        private RelayService _relayService;
        private SubscriberService _subscriberService;
        private readonly Message _message = new Message();

        [GlobalSetup]
        public void Setup()
        {
            _relayService = new RelayService();
            _subscriberService = new SubscriberService(new ChannelFactory(), _relayService);
            _subscriberService.Subscribe(new DummyBinarySubscriber());
        }

        [Benchmark]
        public void RunRelayMessage()
        {
            _relayService.RelayMessage(_message);
            Thread.Sleep(1); // hack - needed to put time between benchmarks. System does not recycle threads fast enought. Probably can be solved properly, just don`t have time to do it now.
        }
    }
}