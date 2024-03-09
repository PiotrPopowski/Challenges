namespace Fetcher.API.Feeds.PublicApi.Http.Models
{
    public record PublicApiEntry(string API, string Description, string Auth, bool HTTPS, string Cors, string Link, string Category);
}
