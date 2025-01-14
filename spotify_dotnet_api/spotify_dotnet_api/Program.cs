using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using static System.Net.WebRequestMethods;
using System.Diagnostics;

namespace spotify_dotnet_api
{
    public class Program
    {

        static async Task Main(string[] args)
        {
           //Process spotifyProcess = System.Diagnostics.Process.Start("\"C:\\Users\\renna\\AppData\\Roaming\\Spotify\\Spotify.exe\"");
           DataStore dataStore = new DataStore();
           HttpClient client = new HttpClient();
           AccessToken token = new AccessToken( client, dataStore);
           Request request = new Request(client, dataStore);
           await token.InitSession(dataStore);
            Console.WriteLine(token.publictoken.access_token);

            System.Threading.Thread.Sleep(2000);


            //dataStore.deviceId = await request.GetDefultDeviceId(token.publictoken.access_token, client);
           Console.WriteLine("        ");
           string trackId = "3Zwu2K0Qa5sT6teCCHPShP";


            //spotifyProcess.Kill(); // Ends the process
            //spotifyProcess.Dispose();

            //await request.GetTrackInfo(trackId, token.publictoken.access_token, client);
            //await request.PlayTrack(token.publictoken.access_token, client, dataStore.deviceId);
            await request.GetAvailableDevices(token.publictoken.access_token, client);
            

            System.Threading.Thread.Sleep(500);
            await request.SkipToNextTrack(token.publictoken.access_token, client, dataStore.deviceId);


        }


    }
}
