namespace spotify_dotnet_api
{
    public class MarketRequest : Request
    {
        public MarketRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }
        public async Task GetAvailableMarkets(string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/markets";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
    }
}
