using Fetcher.API.Audits.Entities;
using MongoDB.Driver;

namespace Fetcher.API.Shared.MongoDb
{
    public class MongoDatabase : IMongoDb
    {
        public IMongoCollection<HttpAudit> HttpAudits { get; private set; }

        public MongoDatabase(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetRequiredSection("MongoDb:ConnectionString").Value);
            HttpAudits = client.GetDatabase("Fetcher").GetCollection<HttpAudit>("HttpAudit");
        }
    }
}
