using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using static System.Net.WebRequestMethods;

namespace spotify_dotnet_api
{
    public class Program
    {
        static async Task Main(string[] args)
        {
           DataStore dataStore = new DataStore();
            HttpClient client = new HttpClient();




            AccessToken token = new AccessToken( client, dataStore);
            Request request = new Request(client, dataStore);
            await token.InitSession(dataStore);
            Console.WriteLine("        ");
            string trackId = "3Zwu2K0Qa5sT6teCCHPShP";
            //https://open.spotify.com/track/2yR2sziCF4WEs3klW1F38d?si=ac96e09f679e49c3

            await request.GetTrackInfo(trackId, token.publictoken.access_token, client);
            await request.PlayTrack(token.publictoken.access_token, client, dataStore.deviceId);
            await request.GetAvailableDevices(token.publictoken.access_token, client);

            System.Threading.Thread.Sleep(500);
            await request.SkipToNextTrack(token.publictoken.access_token, client, dataStore.deviceId);


        }


    }
}
