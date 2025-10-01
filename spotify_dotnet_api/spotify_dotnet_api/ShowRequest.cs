using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify_dotnet_api
{
    public class ShowRequest : Request
    {
        public ShowRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }

        public async Task GetShow(string accessToken, HttpClient client, string showId)
        {
            string url = $"https://api.spotify.com/v1/shows/{showId}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task GetMultipleShows(string accessToken, HttpClient client, string[] showIds)
        {
            foreach (string id in showIds) { await GetShow(accessToken, client, id); }
        }
        public async Task GetShowEpisodes(string accessToken, HttpClient client, string showId)
        {
            string url = $"https://api.spotify.com/v1/shows/{showId}/episodes";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
        public async Task GetSavedShows(string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/shows";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
        public async Task SaveShowForUser(string accessToken, HttpClient client, string showId)
        {
            string url = $"https://api.spotify.com/v1/me/shows?ids={showId}";
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }
        public async Task DeleteShowForUser(string accessToken, HttpClient client, string showId)
        {
            string url = $"https://api.spotify.com/v1/me/shows?ids={showId}";
            await HeaderFormat(client, accessToken);
            await SendDeleteRequest(client, url);
        }

        public async Task CheckSavedShows(string accessToken, HttpClient client, string showId)
        {
            string url = $"https://api.spotify.com/v1/me/shows/contains?ids={showId}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
    }
}
