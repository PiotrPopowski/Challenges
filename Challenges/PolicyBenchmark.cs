using BenchmarkDotNet.Attributes;

namespace Challenges
{
    [MemoryDiagnoser]
    public class PolicyBenchmark
    {
        [Params(0, 30)]
        public double temp;
        [Params(2, 6)]
        public double wind;

        [Benchmark]
        public void OnePolicyAlwaysNew()
        {
            foreach (var i in Enumerable.Range(0, 1000))
            {
                if(new IsHighTempPolicyAlwaysNew(temp, DateTime.Now).IsApplicable())
                {

                }
            }
        }

        [Benchmark]
        public void OnePolicyOnlyOnce()
        {
            var policy = new IsHighTempPolicyOnlyOnce();

            foreach (var i in Enumerable.Range(0, 1000))
            {
                if(policy.IsApplicable(new Context() { Temp = temp, Time = DateTime.Now }))
                {

                }
            }
        }

        [Benchmark]
        public void PolicyBatchAlwaysNew()
        {
            foreach(var i in Enumerable.Range(0,1000))
            {
                if(new WeatherPolicyAlwaysNew(temp, wind, DateTime.Now).IsApplicable())
                {

                }
            }
        }

        [Benchmark]
        public void PolicyBatchOnlyOnce()
        {
            var policy = new WeatherPolicyOnlyOnce();

            foreach (var i in Enumerable.Range(0, 1000))
            {
                if (policy.IsApplicable(new Context() { Temp = temp, WindMPS = wind, Time = DateTime.Now}))
                {

                }
            }
        }
    }
}
