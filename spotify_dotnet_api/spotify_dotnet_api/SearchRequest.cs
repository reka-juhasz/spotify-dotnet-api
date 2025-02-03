using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify_dotnet_api
{
    public class SearchRequest : Request
    {
        public SearchRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }
        public async Task SearchSpotifyAlbum(string accessToken, HttpClient client, string query)
        {
            string url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type={"album"}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
        public async Task SearchSpotifyArtist(string accessToken, HttpClient client, string query)
        {
            string url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type={"artist"}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
        public async Task SearchSpotifyPlaylist(string accessToken, HttpClient client, string query)
        {
            string url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type={"playlist"}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task SearchSpotifyTrack(string accessToken, HttpClient client, string query)
        {
            string url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type={"track"}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
        public async Task SearchSpotifyShow(string accessToken, HttpClient client, string query)
        {
            string url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type={"show"}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task SearchSpotifyEpisode(string accessToken, HttpClient client, string query)
        {
            string url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type={"episode"}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task SearchSpotifyAudiobook(string accessToken, HttpClient client, string query)
        {
            string url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type={"audiobook"}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
    }
}
