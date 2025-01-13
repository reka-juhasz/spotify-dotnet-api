using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify_dotnet_api
{
    public class DataStore
    {
        public DataStore() { }
            public string clientId = ""; // Replace with your actual client ID
            public string clientSecret = ""; // Replace with your actual client secret
            public string redirectUri = "http://localhost:8888/callback"; // Ensure this matches your Spotify app settings
            public string scope = "user-library-read playlist-read-private user-modify-playback-state user-read-playback-state"; // Example scope; adjust as needed
            //string tokenFilePath = "token.json"; // Path to save/load tokens
            public string deviceId = "";

        public string ClientId { get { return clientId; } set { clientId = value; } }
        public string ClientSecret { get {  return clientSecret; } set { clientSecret = value; } }
        public string RedirectUri { get {   return redirectUri; } set { redirectUri = value; } }
        public string Scope { get { return scope; } set { scope = value; } }
        public string DeviceId { get {  return deviceId; } set { deviceId = value; } }


            








        
    }
}
