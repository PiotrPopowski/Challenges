using Fetcher.API.Audits.Entities;
using MongoDB.Driver;

namespace Fetcher.API.Shared.MongoDb
{
    public interface IMongoDb
    {
        IMongoCollection<HttpAudit> HttpAudits { get; }
    }
}
