namespace spotify_dotnet_api
{
    public class DataStore
    {
        //The clientId, clientSecret and deviceId are empty on purpose. You can generate a clientId and clientSecret 
        //by creating an app on Spotify for Developers. (https://developer.spotify.com/documentation/web-api/tutorials/getting-started#create-an-app)
        //here you will be provided with a the id and secret.
        //create a .txt in the /bin/Debug/dotnet-8.0 folder and paste the id and secret into it.
        public string clientId = ""; 
        public string clientSecret = ""; 
        public string redirectUri = "http://localhost:8888/callback"; 
        public string scope = "ugc-image-upload playlist-modify-public playlist-modify-private user-read-playback-position user-read-playback-state user-read-playback-position user-library-read playlist-read-private user-modify-playback-state user-read-playback-state user-library-modify user-read-recently-played"; 
                                                                                                                            
        public string deviceId = "";
        public DataStore() {

            string fileName = "api_keys.txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);
            this.clientId = lines[0];
            this.clientSecret = lines[1];
            this.deviceId = lines[2];

            Console.WriteLine(clientId);
            Console.WriteLine(clientSecret);
            Console.WriteLine(deviceId);

        }
        public string ClientId { get { return clientId; } set { clientId = value; } }
        public string ClientSecret { get {  return clientSecret; } set { clientSecret = value; } }
        public string RedirectUri { get {   return redirectUri; } set { redirectUri = value; } }
        public string Scope { get { return scope; } set { scope = value; } }
        public string DeviceId { get {  return deviceId; } set { deviceId = value; } }       
    }
}
