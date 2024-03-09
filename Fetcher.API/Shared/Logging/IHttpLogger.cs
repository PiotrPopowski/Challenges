using System.Net;

namespace Fetcher.API.Shared.Logging
{
    public interface IHttpLogger
    {
        Task LogAsync(string request, string response, HttpStatusCode httpStatusCode);
    }
}
