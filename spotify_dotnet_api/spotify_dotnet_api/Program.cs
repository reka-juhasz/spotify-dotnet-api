﻿using System.Text;

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

            AlbumRequest albumRequest = new AlbumRequest(client, dataStore);
            ArtistRequest artistRequest = new ArtistRequest(client, dataStore);
            CategoryRequest categoryRequest = new CategoryRequest(client, dataStore);   
            EpisodeRequest episodeRequest = new EpisodeRequest(client, dataStore);
            MarketRequest marketRequest = new MarketRequest(client, dataStore);
            PlayerRequest playerRequest = new PlayerRequest(client, dataStore);

            string trackId = "0ivCnFLnjjgjDSRMSz0kik";// mr. kitty - dream diver

            string albumId = "4sD1qg4jwTZR4mvR4Iflk5";// lord huron - strange trails 
            string[] albums = { "7EbRbTKOAx4p2xgpSDzuP3", "3cQO7jp5S9qLBoIVtbkSM1", "52abbUrmRs1bmdVp01U9e2" }; //mr. kitty - a.i., twenty one pilots - blurryface, chase atlantic - beauty in death

            string artistId = "5v2WhpA59TJSdPh7LCx1lN"; // BONES
            string[] artists = { "5v2WhpA59TJSdPh7LCx1lN" , "6PfSUFtkMVoDkx4MQkzOi3", "3QaxveoTiMetZCMp1sftiu" }; //BONES, 100gec, waterparks

            string categoryId = "0JQ5DAqbMKFz6FAsUtgAab"; // made for you

            string episodeId = "6zs79bz9Nb0lXhoHtGDudJ"; // welcome night vale ep 1.
            string[] episodes = { "6zs79bz9Nb0lXhoHtGDudJ", "2JYJ9OCjJRhkAhAZ5TqKij", "2Vp7UdSnYpX4Jldd5exkqt" }; // welcome night vale ep 1., cortex ep 1., magnus archives ep 1. 

            //////////////////////////////////
            await token.InitSession(dataStore);
            //////////////////////////////////
            ///


            await playerRequest.StartOrResumeTrack(token.publictoken.access_token, client, "ec2c92eea7bd509618e8f79e7188eaf7fdf8f0c3");

            Thread.Sleep(5000);

            await playerRequest.PauseTrack(token.publictoken.access_token, client, "ec2c92eea7bd509618e8f79e7188eaf7fdf8f0c3");

            //Thread.Sleep(50);

            //await playerRequest.SkipToNextTrack(token.publictoken.access_token, client, "ec2c92eea7bd509618e8f79e7188eaf7fdf8f0c3");

            //Thread.Sleep(5000);

            //await playerRequest.SkipToPreviousTrack(token.publictoken.access_token, client, "ec2c92eea7bd509618e8f79e7188eaf7fdf8f0c3");
            //Thread.Sleep(50);
            //await playerRequest.SetRepeatMode(token.publictoken.access_token, client, RepeatEnum.OFF);

            //await playerRequest.GetRecentlyPlayedTracks(token.publictoken.access_token, client);
            await playerRequest.AddItemToQueue(token.publictoken.access_token, client, episodeId, true);




        }
    }
}
