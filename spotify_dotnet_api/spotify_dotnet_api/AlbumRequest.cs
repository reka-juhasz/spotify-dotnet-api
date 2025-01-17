using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify_dotnet_api
{
    public class AlbumRequest : Request
    {
        public AlbumRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }

        //returns info on requested album
        public async Task GetAlbumInfo( string albumId, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/albums/{albumId}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
        //returns info on multiple selected albums
        public async Task GetMultipleAlbums(string[] albumIds, string aceessToken, HttpClient client)
        {
            foreach (string albumId in albumIds)
            {
                await GetAlbumInfo(albumId, aceessToken, client);
            }
        }

        //returns the tracks on requested album
        public async Task GetAlbumTracks(string albumId, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/albums/{albumId}/tracks";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);

        }
        
        //returns user's saved albums 
        public async Task GetUserSavedAlbums( string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/albums";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        //saves requested albums to user's library 
        public async Task SaveAlbumsForCurrentUser(string[] albumIds, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/albums?ids=";
            foreach (string albumId in albumIds)
            {

                url = url + albumId + ",";
            }
            url = url.Remove(url.Length - 1);
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }

        //deleted requested albums from user's library
        public async Task DeleteAlbumsForCurrentUser(string[] albumIds, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/albums?ids=";
            foreach (string albumId in albumIds)
            {

                url = url + albumId + ",";
            }
            url = url.Remove(url.Length - 1);
            await HeaderFormat(client, accessToken);
            await SendDeleteRequest(client, url);
        }

        //checks wether requested albums are saved or not
        public async Task CheckUsersSavedAlbums(string[] albumIds, string accessToken, HttpClient client)
        {
            string url = "https://api.spotify.com/v1/me/albums/contains?ids=";
            foreach (string albumId in albumIds)
            {

                url = url + albumId + ",";
            }
            url = url.Remove(url.Length - 1);
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        //shows new releases
        public async Task GetNewReleases(string accessToken, HttpClient client)
        {
            string url = "https://api.spotify.com/v1/browse/new-releases";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);



        }

    }
}
