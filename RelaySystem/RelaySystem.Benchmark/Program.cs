using BenchmarkDotNet.Running;

namespace RelaySystem.Benchmark
{
    class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BinaryChannelBenchmark>();
            BenchmarkRunner.Run<HttpChannelBenchmark>();
            System.Console.ReadKey();
        }
    }
}
