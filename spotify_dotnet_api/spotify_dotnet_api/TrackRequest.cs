namespace spotify_dotnet_api
{
    public class TrackRequest : Request
    {
        public TrackRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }

        public async Task GetTrack( string accessToken, HttpClient client, string trackId)
        {
            string url = $"https://api.spotify.com/v1/tracks/{trackId}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task GetUsersSavedTrack( string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/tracks";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task SaveTrack( string accessToken, HttpClient client, string trackId)
        {
            string url = $"https://api.spotify.com/v1/me/tracks?ids={trackId}";
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }

        public async Task DeleteTrack( string accessToken, HttpClient client,string trackId)
        {
            string url = $"https://api.spotify.com/v1/me/tracks?ids={trackId}";
            await HeaderFormat(client, accessToken);
            await SendDeleteRequest(client, url);
        }

        public async Task CheckUserSavedTrack(string accessToken, HttpClient client, string trackId)
        {
            string url = $"https://api.spotify.com/v1/me/tracks/contains?ids={trackId}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
    }
}
