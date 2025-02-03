using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify_dotnet_api
{
    public class UserRequest : Request
    {
        public UserRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }

        public async Task GetCurrentUser(string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task GetTopItem(string accessToken, HttpClient client, TypeEnum type)
        {
            string multiple_type = type.ToString() + "s";
            string url = $"https://api.spotify.com/v1/me/top/{multiple_type}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task GetAUser(string accessToken, HttpClient client, string userId)
        {
            string url = $"https://api.spotify.com/v1/users/{userId}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
        public async Task FollowPlaylist(string accessToken, HttpClient client, string playlistId)
        {
            string url = $"https://api.spotify.com/v1/playlists/{playlistId}/followers";
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }
        public async Task UnFollowPlaylist(string accessToken, HttpClient client, string playlistId)
        {
            string url = $"https://api.spotify.com/v1/playlists/{playlistId}/followers";
            await HeaderFormat(client, accessToken);
            await SendDeleteRequest(client, url);
        }

        public async Task GetFollowedArtists(string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/following?type=artist";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task FollowArtistOrUser(string accessToken, HttpClient client, TypeEnum type,  string Id)
        {
            //exception handling needed
            string url = $"https://api.spotify.com/v1/me/following?type={type.ToString()}&ids={Id}";
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }

        public async Task UnollowArtistOrUser(string accessToken, HttpClient client, TypeEnum type, string Id)
        {
            //exception handling needed
            string url = $"https://api.spotify.com/v1/me/following?type={type.ToString()}&ids={Id}";
            await HeaderFormat(client, accessToken);
            await SendDeleteRequest(client, url);
        }

        public async Task CheckIfUserFollowsUserOrArtist(string accessToken, HttpClient client, TypeEnum type, string Id)
        {
            //exception handling needed
            string url = $"https://api.spotify.com/v1/me/following/contains?type={type.ToString()}&ids={Id}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
        public async Task CheckIfUserFollowsPlaylist(string accessToken, HttpClient client,  string playlistId)
        {
            //exception handling needed
            string url = $"https://api.spotify.com/v1/playlists/{playlistId}/followers/contains";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }






    }
}
