
using System.Text;
using System.Text.Json;

namespace spotify_dotnet_api
{
    public class Request
    {
        public HttpClient client;
        public TokenResponse publictoken;
        public DataStore dataStore;
        StringContent defaultContent = new StringContent("{}", Encoding.UTF8, "application/json");

        public Request(HttpClient client, DataStore dataStore)
        {
            this.client = client;
            this.dataStore = dataStore;
        }


        public async Task HeaderFormat(HttpClient client, string accessToken)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        }

        public async Task SendGetRequest(HttpClient client, string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    string[] content_list = content.Split(',');
                    foreach (string line in content_list) { Console.WriteLine(line); }

                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
        public async Task<String> SendGetRequestReturnString(HttpClient client, string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    string[] content_list = content.Split(',');
                    return content;

                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return "";
            

        }

        public async Task SendPutRequest(HttpClient client, string url) 
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync(url, defaultContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Put request sent successfully.");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    Console.WriteLine($"Error: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public async Task SendPostRequest(HttpClient client, string url) 
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(url, defaultContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Send request sent successfully.");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    Console.WriteLine($"Error: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public async Task SendDeleteRequest(HttpClient client, string url)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Requested items were deleted!");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    Console.WriteLine($"Error: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //////////

        public async Task GetTrackInfo(string trackId, string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/tracks/{trackId}"; 
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task GetAvailableDevices( string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/player/devices";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task PlayTrack(string accessToken, HttpClient client, string deviceId)
        {
            string url = $"https://api.spotify.com/v1/me/player/play?device_id={deviceId}";
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }
        public async Task<String> GetDefultDeviceId(string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/player/devices"; // Build the URL
            await HeaderFormat(client, accessToken);
           string jsonString = await SendGetRequestReturnString(client, url);
            using JsonDocument doc = JsonDocument.Parse(jsonString);
            JsonElement root = doc.RootElement;
            string id = root.GetProperty("devices")[0].GetProperty("id").GetString();
            return id;
        }
        public async Task SkipToNextTrack(string accessToken, HttpClient client, string deviceId)
        {
            string url = $"https://api.spotify.com/v1/me/player/next?device_id={deviceId}";
            await SendPostRequest(client, url);
        }
    }
}