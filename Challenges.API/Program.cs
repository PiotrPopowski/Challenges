using Challenges.API.Behaviors;
using Challenges.API.Configuration;
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
            // Add Metrics
            builder.Services.AddWebMetrics();

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

            app.UseRouting();
            app.UseWebMetrics();

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
