using Fetcher.API.Audits.Entities;
using Fetcher.API.Shared.MongoDb;
using MongoDB.Driver;

namespace Fetcher.API.Audits.Services
{
    public class AuditService : IAuditService
    {
        private readonly IMongoCollection<HttpAudit> _audits;

        public AuditService(IMongoDb mongoDb)
        {
            _audits = mongoDb.HttpAudits;
        }

        public async Task<List<HttpAudit>> GetAllAsync()
            => await _audits.Find(x => true).ToListAsync();
    }
}
