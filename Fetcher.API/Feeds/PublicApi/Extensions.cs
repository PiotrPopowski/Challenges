using Fetcher.API.Feeds.PublicApi.Http;

namespace Fetcher.API.Feeds.PublicApi;

public static class Extensions
{
    public static IServiceCollection RegisterPublicApiClient(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddHttpClient<IPublicApiHttpClient, PublicApiHttpClient>()
                .ConfigureHttpClient(cfg =>
                {
                    cfg.BaseAddress = new Uri(configuration.GetRequiredSection("PublicApi:BaseUrl").Value);
                })
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new SocketsHttpHandler()
                    {
                        PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1)
                    };
                })
                .SetHandlerLifetime(Timeout.InfiniteTimeSpan).Services;
}
