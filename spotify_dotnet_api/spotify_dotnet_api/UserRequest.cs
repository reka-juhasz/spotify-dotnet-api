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

        public async Task GetCurrentUserInfo(string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }



    }
}
