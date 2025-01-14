using System;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Start Spotify Web Player
            await SpotifyWebPlayer.StartAsync();
            await SpotifyWebPlayer.CheckAvailableDevicesAsync();
            await SpotifyWebPlayer.PlayTrackAsync("spotify:track:3n3PpT7bH4B5TjbXkKXQXb");

            // Test if the player is initialized and connected
            bool isConnected = await SpotifyWebPlayer.TestPlayerConnectionAsync();
            if (isConnected)
            {
                Console.WriteLine("Player SDK is functioning correctly!");
            }
            else
            {
                Console.WriteLine("Player SDK failed to connect.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
