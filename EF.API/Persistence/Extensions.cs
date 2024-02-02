using Microsoft.EntityFrameworkCore;

namespace EF.API.Persistence
{
    public static class Extensions
    {
        public static IServiceCollection AddMSSQL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MSSQL"));
            });

            return services;
        }
    }
}
