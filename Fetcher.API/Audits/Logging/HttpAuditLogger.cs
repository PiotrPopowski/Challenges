using Fetcher.API.Audits.Entities;
using Fetcher.API.Shared.Logging;
using Fetcher.API.Shared.MongoDb;
using MongoDB.Driver;
using System.Net;

namespace Fetcher.API.Audits.Logging
{
    public class HttpAuditLogger : IHttpLogger
    {
        IMongoCollection<HttpAudit> _httpAudits;

        public HttpAuditLogger(IMongoDb mongoDb)
        {
            _httpAudits = mongoDb.HttpAudits;
        }

        public async Task LogAsync(string request, string response, HttpStatusCode httpStatusCode)
        {
            await _httpAudits.InsertOneAsync(new HttpAudit(request, response, (int)httpStatusCode));
        }
    }
}
