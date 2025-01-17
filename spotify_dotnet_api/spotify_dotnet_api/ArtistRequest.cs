using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify_dotnet_api
{
    public class ArtistRequest : Request
    {
        public ArtistRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }

        public async Task GetArtistInfo(string artistId, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/artists/{artistId}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }


        public async Task GetMultipleArtistInfo(string[] artists, string accessToken, HttpClient client)
        {
            string url = "https://api.spotify.com/v1/artists?ids=";
            foreach (string artistId in artists)
            {
                await GetArtistInfo(artistId, accessToken, client);
            }
        }

        public async Task GetArtistAlbums(string artistId, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/artists/{artistId}/albums";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task GetArtistTopTracks(string artistId, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/artists/{artistId}/top-tracks";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
    }
}
