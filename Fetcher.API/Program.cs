using Fetcher.API.Audits;
using Fetcher.API.Audits.Logging;
using Fetcher.API.Audits.Services;
using Fetcher.API.Feeds;
using Fetcher.API.Shared.MongoDb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterFeedServices(builder.Configuration);
builder.Services.AddHttpAuditLogger();
builder.Services.AddMongoDb();
builder.Services.RegisterAuditServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/audits", async (IAuditService auditService) =>
{
    return Results.Ok(await auditService.GetAllAsync());
})
.WithName("Audits");

app.Run();