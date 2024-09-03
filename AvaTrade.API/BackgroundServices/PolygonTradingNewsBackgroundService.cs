namespace AvaTrade.API.BackgroundServices
{
    public class PolygonTradingNewsBackgroundService : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "YOUR_POLYGON_API_KEY"; // taking from configuration

        public PolygonTradingNewsBackgroundService()
        {
            _httpClient = new HttpClient();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await DoWorkAsync(stoppingToken);

                // Wait for 1 hour before the next execution
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private async Task DoWorkAsync(CancellationToken cancellationToken)
        {
            try
            {
                // Replace with your Polygon API endpoint
                //var requestUri = $"https://api.polygon.io/v2/reference/news?apiKey={_apiKey}";
                //var response = await _httpClient.GetStringAsync(requestUri);

                // Implement your logic here to handle the fetched data
            }
            catch (Exception ex)
            {
                //logging
            }
        }
    }
}
