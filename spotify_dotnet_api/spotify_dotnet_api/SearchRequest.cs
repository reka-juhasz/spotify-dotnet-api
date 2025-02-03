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
        public async Task SearchSpotify(string accessToken, HttpClient client, string query, SearchEnum type)
        {
            string url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type={type.ToString()}";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }
    }
}
