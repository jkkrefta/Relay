using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using RelaySystem.Benchmark.TestDummies;
using RelaySystem.Factories;
using RelaySystem.Models;
using RelaySystem.Services;

namespace RelaySystem.Benchmark.Benchmarks
{
    [CoreJob]
    public class BinaryChannelBenchmark
    {
        private DispatcherService _dispatcherService;
        private SubscriberService _subscriberService;
        private readonly Message _message = new Message();

        [GlobalSetup]
        public void Setup()
        {
            _dispatcherService = new DispatcherService();
            _subscriberService = new SubscriberService(new ChannelFactory(), _dispatcherService);
            _subscriberService.Subscribe(new DummyBinarySubscriber());
        }

        [Benchmark]
        public void RunRelayMessage()
        {
            _dispatcherService.DispatchMessage(_message);
            Thread.Sleep(1); // hack - needed to put time between benchmarks. System does not recycle threads fast enought. Probably can be solved properly, just don`t have time to do it now.
        }
    }
}