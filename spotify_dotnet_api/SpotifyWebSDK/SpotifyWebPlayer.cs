using Microsoft.AspNetCore.Mvc;
using SpotifyWebSDK;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public static class SpotifyWebPlayer
{
    private static string _accessToken;
    public static string token = _accessToken; // Get the access token
    public static string htmlContent = File.ReadAllText("index.html");


    public static async Task StartAsync()
    {
        try
        {
            Console.WriteLine("Starting authentication...");
            HttpClient client = new HttpClient();
            DataStore datastore = new DataStore("8ca63e16a7074f88a71dc32119ae3a15", "b7d47e3311c24407a55a6f387e699f04");
            AccessToken auth = new AccessToken(client, datastore);

            Console.WriteLine("Initializing session...");
            await auth.InitSession(datastore);

            _accessToken = auth.publictoken.access_token;

            // Check if the token was successfully retrieved
            if (string.IsNullOrEmpty(_accessToken))
            {
                Console.WriteLine("Failed to authenticate with Spotify. Token is null or empty.");
                return;
            }

            Console.WriteLine($"Access Token: {_accessToken}");

            // Dynamically read and update HTML content with access token after token retrieval
            string htmlContent = File.ReadAllText("index.html");
            htmlContent = htmlContent.Replace("@auth.publictoken.access_token", _accessToken);

            // Ensure the path is correct before saving
            string filePath = "C:\\Users\\renna\\source\\repos\\spotify-dotnet-api\\spotify_dotnet_api\\SpotifyWebSDK\\wwwroot\\index.html";
            File.WriteAllText(filePath, htmlContent);

            Console.WriteLine("HTML content updated successfully.");

            // Test player connection
            Console.WriteLine("Testing player connection...");
            bool playerConnected = await TestPlayerConnectionAsync();
            if (playerConnected)
            {
                Console.WriteLine("Player connection successful!");
            }
            else
            {
                Console.WriteLine("Player connection failed. No devices found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during startup: {ex.Message}");
        }
    }



    private static async Task GetCurrentUserProfileAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);

            HttpResponseMessage response = await client.GetAsync("https://api.spotify.com/v1/me");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var userProfile = JsonSerializer.Deserialize<JsonElement>(jsonResponse);
                Console.WriteLine("User Profile:");
                Console.WriteLine(userProfile.ToString());
            }
            else
            {
                Console.WriteLine($"Failed to fetch user profile. Status Code: {response.StatusCode}");
            }
        }
    }

    public static async Task<bool> TestPlayerConnectionAsync()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                // Get the list of available devices
                HttpResponseMessage response = await client.GetAsync("https://api.spotify.com/v1/me/player/devices");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var devices = JsonSerializer.Deserialize<JsonElement>(jsonResponse);

                    Console.WriteLine("Available Devices:");
                    Console.WriteLine(devices.ToString());

                    // Check if any devices are registered
                    JsonElement deviceArray = devices.GetProperty("devices");
                    if (deviceArray.GetArrayLength() > 0)
                    {
                        Console.WriteLine("Player SDK is connected and functioning!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("No active devices found. Please ensure a player is available.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve devices. Status Code: {response.StatusCode}");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error testing player connection: {ex.Message}");
            return false;
        }
    }


    public static async Task PlayTrackAsync(string trackUri)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var content = new StringContent(
                    JsonSerializer.Serialize(new { uris = new[] { trackUri } }),
                    Encoding.UTF8, "application/json"
                );

                HttpResponseMessage response = await client.PutAsync("https://api.spotify.com/v1/me/player/play", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Track started playing!");
                }
                else
                {
                    Console.WriteLine($"Failed to play track. Status Code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing track: {ex.Message}");
        }
    }

    public static async Task CheckAvailableDevicesAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            HttpResponseMessage response = await client.GetAsync("https://api.spotify.com/v1/me/player/devices");

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var devices = JsonSerializer.Deserialize<JsonElement>(jsonResponse);

                Console.WriteLine("Available Devices:");
                Console.WriteLine(devices.ToString());

                JsonElement deviceArray = devices.GetProperty("devices");
                if (deviceArray.GetArrayLength() > 0)
                {
                    Console.WriteLine("Devices found!");
                }
                else
                {
                    Console.WriteLine("No active devices found.");
                }
            }
            else
            {
                Console.WriteLine($"Failed to retrieve devices. Status Code: {response.StatusCode}");
            }
        }
    }




}
