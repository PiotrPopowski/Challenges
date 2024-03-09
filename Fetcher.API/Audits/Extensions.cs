using Fetcher.API.Audits.Services;

namespace Fetcher.API.Audits
{
    public static class Extensions
    {
        public static IServiceCollection RegisterAuditServices(this IServiceCollection services)
            => services.AddScoped<IAuditService, AuditService>();
    }
}
