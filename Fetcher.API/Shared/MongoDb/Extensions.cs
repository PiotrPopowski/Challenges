namespace Fetcher.API.Shared.MongoDb
{
    public static class Extensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services)
            => services.AddSingleton<IMongoDb, MongoDatabase>();
    }
}
