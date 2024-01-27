using Prometheus;
using Prometheus.HttpMetrics;
using System.Runtime.CompilerServices;

namespace Challenges.API.Configuration
{
    public static class Metrics
    {
        public static IServiceCollection AddWebMetrics(this IServiceCollection services)
        {
            return services;
        }

        public static IApplicationBuilder UseWebMetrics(this IApplicationBuilder app)
        {
            var metricFactory = Prometheus.Metrics.WithManagedLifetime(expiresAfter: TimeSpan.FromSeconds(60));

            app.UseMiddleware<MetricsMiddleware>();

            app.UseHttpMetrics(opt => opt.AddCustomLabel("url", ctx => ctx.Request.Path));
            app.UseEndpoints(opt => opt.MapMetrics());

            return app;
        }
    }
}
