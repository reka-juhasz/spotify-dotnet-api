using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify_dotnet_api
{
    public class EpisodeRequest : Request
    {
        public EpisodeRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }

        public async Task GetEpisodeInfo(string episodeId, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/episodes/{episodeId}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task GetMultipleEpisodeInfo(string[] episodes, string accessToken, HttpClient client)
        {
            string url = "https://api.spotify.com/v1/artists?ids=";
            foreach (string episodeId in episodes)
            {
                await GetEpisodeInfo(episodeId, accessToken, client);
            }
        }

        public async Task GetUserSavedEpisodes(string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/episodes";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task SaveEpisodesForCurrentUser(string[] episodes, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/episodes?ids=";
            foreach (string episodeId in episodes)
            {

                url = url + episodeId + ",";
            }
            url = url.Remove(url.Length - 1);
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }

        //deleted requested episodes from user's library
        public async Task DeleteEpisodesForCurrentUser(string[] episodes, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/episodes?ids=";
            foreach (string episodeId in episodes)
            {

                url = url + episodeId + ",";
            }
            url = url.Remove(url.Length - 1);
            await HeaderFormat(client, accessToken);
            await SendDeleteRequest(client, url);
        }

        public async Task CheckUsersSavedEpisodes(string[] episodes, string accessToken, HttpClient client)
        {
            string url = "https://api.spotify.com/v1/me/episodes/contains?ids=";
            foreach (string episodeId in episodes)
            {

                url = url + episodeId + ",";
            }
            url = url.Remove(url.Length - 1);
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }


    }
}
