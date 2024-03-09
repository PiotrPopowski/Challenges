using Fetcher.API.Feeds.PublicApi;

namespace Fetcher.API.Feeds
{
    public static class Extensions
    {
        public static IServiceCollection RegisterFeedServices(this IServiceCollection services, IConfiguration configuration)
            => services.RegisterPublicApiClient(configuration)
                       .AddHostedService<PublicApiBackgroundService>();
    }
}
