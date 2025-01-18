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

            string trackId = "0ivCnFLnjjgjDSRMSz0kik";// mr. kitty - dream diver

            string albumId = "4sD1qg4jwTZR4mvR4Iflk5";// lord huron - strange trails 
            string[] albums = { "7EbRbTKOAx4p2xgpSDzuP3", "3cQO7jp5S9qLBoIVtbkSM1", "52abbUrmRs1bmdVp01U9e2" }; //mr. kitty - a.i., twenty one pilots - blurryface, chase atlantic - beauty in death

            string artistId = "5v2WhpA59TJSdPh7LCx1lN"; // BONES
            string[] artists = { "5v2WhpA59TJSdPh7LCx1lN" , "6PfSUFtkMVoDkx4MQkzOi3", "3QaxveoTiMetZCMp1sftiu" }; //BONES, 100gec, waterparks

            string categoryId = "0JQ5DAqbMKFz6FAsUtgAab"; //made for you


            //////////////////////////////////
            await token.InitSession(dataStore);
            //////////////////////////////////



            await categoryRequest.GetConcreteCategory(categoryId, token.publictoken.access_token, client);

            await categoryRequest.GetMultipleCategories(token.publictoken.access_token, client);
            
            
            





        }
    }
}
