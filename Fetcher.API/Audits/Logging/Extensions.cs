using Fetcher.API.Shared.Logging;

namespace Fetcher.API.Audits.Logging
{
    public static class Extensions
    {
        public static IServiceCollection AddHttpAuditLogger(this IServiceCollection services)
            => services.AddSingleton<IHttpLogger, HttpAuditLogger>();
    }
}
