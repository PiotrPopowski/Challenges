using App.Metrics;
using Challenges.API.Behaviors;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Challenges.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<KestrelServerOptions>(opt => opt.AllowSynchronousIO = true);
            builder.Logging.AddConsole();
            // Add services to the container.

            var metrics = AppMetrics.CreateDefaultBuilder().Build();
            builder.Services.AddMetrics(metrics);
            builder.Services.AddMetricsEndpoints();
            builder.Services.AddMetricsTrackingMiddleware();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(cfg => 
            {
                cfg.AddOpenBehavior(typeof(LoggingRequestBehavior<,>));
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddLogging();

            var app = builder.Build();
            app.UseMetricsAllEndpoints();
            app.UseMetricsAllMiddleware();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
