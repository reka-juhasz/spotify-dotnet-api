﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyWebSDK
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
        public string scope = "user-library-read playlist-read-private user-modify-playback-state user-read-playback-state";

        public string deviceId = "";

        public DataStore(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        
        }

        public DataStore()
        {

            string fileName = "api_keys.txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);
            clientId = lines[0];
            clientSecret = lines[1];
            deviceId = lines[2];

            Console.WriteLine(clientId);
            Console.WriteLine(clientSecret);
            Console.WriteLine(deviceId);

        }





        public string ClientId { get { return clientId; } set { clientId = value; } }
        public string ClientSecret { get { return clientSecret; } set { clientSecret = value; } }
        public string RedirectUri { get { return redirectUri; } set { redirectUri = value; } }
        public string Scope { get { return scope; } set { scope = value; } }
        public string DeviceId { get { return deviceId; } set { deviceId = value; } }












    }
}
