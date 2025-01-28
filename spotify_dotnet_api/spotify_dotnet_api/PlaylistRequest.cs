using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify_dotnet_api
{
    public class PlaylistRequest : Request
    {
        public PlaylistRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }

        public async Task GetPlaylist(string accessToken, HttpClient client, string playlistId)
        {
            string url = $"https://api.spotify.com/v1/playlists/{playlistId}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task ChangePlaylistName(string accessToken, HttpClient client, string playlistId, string newName)
        {
            string inner_content = $"{{\"name\": \"{newName}\"}}";
            await ChangePlaylist(inner_content, accessToken, playlistId);
        }

        public async Task ChangePlaylistToPublic(string accessToken, HttpClient client, string playlistId)
        {
            string inner_content = $"{{\"public\": \"{"true"}\"}}";
            await ChangePlaylist(inner_content, accessToken, playlistId);
        }

        public async Task ChangePlaylistToPrivate(string accessToken, HttpClient client, string playlistId)
        {
            string inner_content = $"{{\"public\": \"{"false"}\"}}";
            StringContent content = new StringContent(inner_content, Encoding.UTF8, "application/json");
            await ChangePlaylist(inner_content, accessToken, playlistId);    
        }
        public async Task ChangePlaylistToCollaborative(string accessToken, HttpClient client, string playlistId)
        {
            string inner_content = $"{{\"collaborative\": \"{"true"}\"}}";
            StringContent content = new StringContent(inner_content, Encoding.UTF8, "application/json");
            await ChangePlaylist(inner_content, accessToken, playlistId);
        }

        public async Task ChangePlaylistToNonCollaborative(string accessToken, HttpClient client, string playlistId)
        {
            string inner_content = $"{{\"collaborative\": \"{"false"}\"}}";
            await ChangePlaylist(inner_content, accessToken, playlistId);  
        }
        public async Task ChangePlaylistDescription(string accessToken, HttpClient client, string playlistId, string description)
        {
            string inner_content = $"{{\"description\": \"{description}\"}}";
            await ChangePlaylist(inner_content, accessToken, playlistId);
        }



        public async Task UpdatePlaylistItems(string accessToken, HttpClient client, string playlistId, int range_start, int insert_before, int range_length)
        {
            string inner_content = $"{{\"range_start\": {range_start}, \"insert_before\": {insert_before}, \"range_length\": {range_length}}}"; 
            await ChangePlaylist(inner_content, accessToken, playlistId);
        }


        public async Task AddItemsToPlaylist(string accessToken, HttpClient client, string playlistId, string trackId)
        {
            string url = $"https://api.spotify.com/v1/playlists/{playlistId}/tracks";


            string inner_content = $"{{\"uris\": [\"spotify:track:{trackId}\"]}}";
            StringContent content = new StringContent(inner_content, Encoding.UTF8, "application/json");


            await HeaderFormat(client, accessToken);
            await SendPostRequestWithContent(client, url, content);
        }

        private async Task ChangePlaylist(string inner_content, string accessToken, string playlistId) {
            StringContent content = new StringContent(inner_content, Encoding.UTF8, "application/json");
            string url = $"https://api.spotify.com/v1/playlists/{playlistId}";
            await HeaderFormat(client, accessToken);
            await SendPutRequestWithContent(client, url, content);
        }

        public async Task GetPlaylistItem(string accessToken, HttpClient client, string playlistId)
        {
            string url = $"https://api.spotify.com/v1/playlists/{playlistId}/tracks";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }




        public async Task DeleteTrackFromPlaylist(string accessToken, HttpClient client, string playlistId, string trackId)
        {
            string url = $"https://api.spotify.com/v1/playlists/{playlistId}/tracks";

            string inner_content = $"{{\"tracks\":[{{\"uri\":\"spotify:track:{trackId}\"}}]}}"; 
            StringContent content = new StringContent(inner_content, Encoding.UTF8, "application/json");
            await HeaderFormat(client, accessToken);

            await SendDeleteRequestWithContent(client, url, content);



        }

        public async Task GetCurrentUserPlaylist(string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/playlists";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }


    }
}
