using Microsoft.EntityFrameworkCore;

namespace EF.API.Persistence
{
    public static class Extensions
    {
        public static IServiceCollection AddMSSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MSSQL"));
            });

            return services;
        }

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            ApplicationDatabaseSeed.Seed(context).Wait();
        }
    }
}
