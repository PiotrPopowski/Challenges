namespace Fetcher.API.Feeds.PublicApi
{
    public class PublicApiBackgroundService : BackgroundService
    {
        private readonly IPublicApiHttpClient _publicApiClient;
        private int _fetchIntervalInMinutes;

        public PublicApiBackgroundService(IPublicApiHttpClient httpClient, IConfiguration configuration)
        {
            this._publicApiClient = httpClient;
            _fetchIntervalInMinutes = int.Parse(configuration.GetRequiredSection("PublicApi:FetchIntervalInMinutes").Value);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await _publicApiClient.GetAsync();
                await Task.Delay(_fetchIntervalInMinutes * 60 * 1000);
            }
        }
    }
}
