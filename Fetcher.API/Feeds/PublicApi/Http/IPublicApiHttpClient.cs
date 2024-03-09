using Fetcher.API.Feeds.PublicApi.Http.Models;

namespace Fetcher.API.Feeds.PublicApi
{
    public interface IPublicApiHttpClient
    {
        Task<PublicApiModel?> GetAsync();
    }
}
