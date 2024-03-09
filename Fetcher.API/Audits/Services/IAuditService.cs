using Fetcher.API.Audits.Entities;

namespace Fetcher.API.Audits.Services
{
    public interface IAuditService
    {
        Task<List<HttpAudit>> GetAllAsync();
    }
}
