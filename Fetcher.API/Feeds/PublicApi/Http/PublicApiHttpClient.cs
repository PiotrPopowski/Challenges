using Fetcher.API.Feeds.PublicApi.Http.Models;
using Fetcher.API.Shared.Logging;

namespace Fetcher.API.Feeds.PublicApi.Http
{
    public class PublicApiHttpClient : IPublicApiHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpLogger _httpLogger;

        public PublicApiHttpClient(HttpClient httpClient, IHttpLogger httpLogger)
        {
            _httpClient = httpClient;
            this._httpLogger = httpLogger;
        }

        public async Task<PublicApiModel?> GetAsync()
        {
            var result = await _httpClient.GetAsync(PublicApiEndpoints.GetRandom);

            await _httpLogger.LogAsync(_httpClient.BaseAddress + PublicApiEndpoints.GetRandom, await result.Content.ReadAsStringAsync(), result.StatusCode);

            return await result.Content.ReadFromJsonAsync<PublicApiModel?>();
        }
    }
}
