using Prometheus;

namespace Challenges.API
{
    public class MetricsMiddleware
    {
        private static readonly Gauge _durationMetric = Metrics.CreateGauge(
            "http_response_seconds", 
            "Measures http response time",
            new GaugeConfiguration()
            {
                LabelNames = ["url"]
            });
        private readonly RequestDelegate _next;

        public MetricsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (_durationMetric.NewTimer())
            {
                await _next(context);
            }
        }
    }
}
