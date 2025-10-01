namespace spotify_dotnet_api
{
    public class CategoryRequest : Request
    {
        public CategoryRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }
        public async Task GetMultipleCategories(string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/browse/categories";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
        public async Task GetConcreteCategory(string categoryId, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/browse/categories/{categoryId}";

            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
    }
}
