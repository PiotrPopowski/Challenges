using BenchmarkDotNet.Running;

namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<PolicyBenchmark>();
        }
    }
}
