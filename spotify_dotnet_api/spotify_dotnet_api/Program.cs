using System.Text;

namespace spotify_dotnet_api
{

    public class Program
    {
        static async Task Main(string[] args)
        {
            //initializing all possible request types for testing
            DataStore dataStore = new DataStore();
            HttpClient client = new HttpClient();
            Request request = new Request(client, dataStore);
            AlbumRequest albumRequest = new AlbumRequest(client, dataStore);
            ArtistRequest artistRequest = new ArtistRequest(client, dataStore);
            CategoryRequest categoryRequest = new CategoryRequest(client, dataStore);
            EpisodeRequest episodeRequest = new EpisodeRequest(client, dataStore);
            MarketRequest marketRequest = new MarketRequest(client, dataStore);
            PlayerRequest playerRequest = new PlayerRequest(client, dataStore);
            PlaylistRequest playlistRequest = new PlaylistRequest(client, dataStore);
            UserRequest userRequest = new UserRequest(client, dataStore);
            SearchRequest searchRequest = new SearchRequest(client, dataStore);
            TrackRequest trackRequest = new TrackRequest(client, dataStore);
           

            //Creating an AccessToken object and initializing a new session, you may need to log in the browser
            AccessToken accessTokenManager = new AccessToken(client, dataStore);
            await accessTokenManager.InitSession(dataStore);
            //Access token in string for easy method calling
            string token = accessTokenManager.GetToken();

        } 
    }
}