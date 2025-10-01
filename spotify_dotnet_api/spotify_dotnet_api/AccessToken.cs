using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Web;

namespace spotify_dotnet_api
{
    public class AccessToken
    {
        public HttpClient client;
        public DataStore dataStore;
        public TokenResponse publictoken;
        public AccessToken(HttpClient client, DataStore dataStore)
        {
            this.client = client;
            this.dataStore = dataStore;
        }
        public async Task InitSession(DataStore dataStore)
        {
            string authUrl = $"https://accounts.spotify.com/authorize?client_id={dataStore.clientId}&response_type=code&redirect_uri={Uri.EscapeDataString(dataStore.redirectUri)}&scope={Uri.EscapeDataString(dataStore.scope)}";
            OpenBrowser(authUrl);

            // Check if a stored token exists and is valid
            TokenResponse storedToken = publictoken;

            if (storedToken != null && !IsTokenExpired(storedToken))
            {
                // If a valid token is found, use it
                Console.WriteLine($"Using stored Access Token: {storedToken.access_token}");
            }
            else
            {
                // If no valid token, we need to get a new one
                // Listen for the authorization code
                string authorizationCode = await ListenForAuthorizationCode(dataStore.redirectUri);

                if (authorizationCode != null)
                {
                    // Exchange the authorization code for an access token
                    var tokenResponse = await GetSpotifyAccessToken(dataStore, authorizationCode);
                    // Store the new token for future use
                    publictoken = tokenResponse;
                }
                else
                {
                    Console.WriteLine("Failed to get authorization code.");
                }
            }
        }
        public async Task<TokenResponse> GetSpotifyAccessToken(DataStore dataStore, string authorizationCode)
        {
            string tokenUrl = "https://accounts.spotify.com/api/token";

            var postData = new FormUrlEncodedContent(new[]
            {
        new KeyValuePair<string, string>("grant_type", "authorization_code"),
        new KeyValuePair<string, string>("code", authorizationCode),
        new KeyValuePair<string, string>("redirect_uri", dataStore.redirectUri),
        new KeyValuePair<string, string>("client_id", dataStore.clientId),
        new KeyValuePair<string, string>("client_secret", dataStore.clientSecret)
    });
            var byteArray = Encoding.ASCII.GetBytes($"{dataStore.clientId}:{dataStore.clientSecret}");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client.PostAsync(tokenUrl, postData);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseContent}");
            }
            return JsonConvert.DeserializeObject<TokenResponse>(responseContent);
        }
        public async Task<string> ListenForAuthorizationCode(string redirectUri)
        {
            string authorizationCode = null;
            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add(redirectUri + "/");
                listener.Start();
                Console.WriteLine("Waiting for authorization code...");

                var context = await listener.GetContextAsync();
                var query = context.Request.Url.Query;

                var code = HttpUtility.ParseQueryString(query).Get("code");
                authorizationCode = code;
                string responseString = "<html><body><h1>Authorization successful! You can close this window.</h1></body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                context.Response.ContentLength64 = buffer.Length;
                await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();
                listener.Stop();
            }
            return authorizationCode;
        }
        public void OpenBrowser(string url)
        {
            if (System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            }) == null)
            {
                Console.WriteLine("Failed to open the browser.");
            }
        }
        public bool IsTokenExpired(TokenResponse token)
        {
            return token.expires_in <= 0;
        }
        public string GetToken()
        {
            return this.publictoken.access_token;
        }   
    }
}
public class TokenResponse
{
    public string access_token { get; set; }
    public string refresh_token { get; set; }
    public int expires_in { get; set; }
}