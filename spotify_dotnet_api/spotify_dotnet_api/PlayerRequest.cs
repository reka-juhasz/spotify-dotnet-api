using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify_dotnet_api
{
    public class PlayerRequest : Request
    {
        public PlayerRequest(HttpClient client, DataStore dataStore) : base(client, dataStore)
        {
        }
        public async Task GetPlaybackState(string accessToken, HttpClient client)
        {
            string url = "https://api.spotify.com/v1/me/player";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);

        }

        public async Task TransferPlayback(string accessToken, HttpClient client, string deviceId)
        {
            string inner_content = $"{{\"device_ids\": [\"{deviceId}\"]}}";
            StringContent content = new StringContent(inner_content, Encoding.UTF8, "application/json");
            string url = "https://api.spotify.com/v1/me/player";
            await HeaderFormat(client, accessToken);
            await SendPutRequestWithContent(client, url, content);
        }


        public async Task GetAvailableDevices(string accessToken, HttpClient client)
        {
            string url = $"https://api.spotify.com/v1/me/player/devices";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);
        }

        public async Task GetCurrentlyPlayingTrack(string accessToken, HttpClient client)
        {
            string url = "https://api.spotify.com/v1/me/player/currently-playing";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);

        }

        public async Task StartOrResumeTrack(string accessToken, HttpClient client, string deviceId)
        {
            string url = $"https://api.spotify.com/v1/me/player/play?device_id={deviceId}";
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }

        public async Task PauseTrack(string accessToken, HttpClient client, string deviceId)
        {
            string url = $"https://api.spotify.com/v1/me/player/pause?device_id={deviceId}";
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }

        public async Task SkipToNextTrack(string accessToken, HttpClient client, string deviceId)
        {
            string url = $"https://api.spotify.com/v1/me/player/next?device_id={deviceId}";
            await SendPostRequest(client, url);
        }
        public async Task SkipToPreviousTrack(string accessToken, HttpClient client, string deviceId)
        {
            string url = $"https://api.spotify.com/v1/me/player/previous?device_id={deviceId}";
            await SendPostRequest(client, url);
        }

        public async Task SeekToPosition(string accessToken, HttpClient client, int position)
        {
            if (position < 0) { position *= -1; }
            string url = $"https://api.spotify.com/v1/me/player/seek?position_ms={position}";
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }

        public async Task SetRepeatMode(string accessToken, HttpClient client, RepeatEnum repeatEnum)
        {
            string url = "";
            if (repeatEnum == RepeatEnum.TRACK)
            {
                 url = $"https://api.spotify.com/v1/me/player/repeat?state=track";
            }
            if (repeatEnum == RepeatEnum.CONTEXT)
            {
                url = $"https://api.spotify.com/v1/me/player/repeat?state=context";
            }
            else
            {
                url = $"https://api.spotify.com/v1/me/player/repeat?state=off";
            }
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }

        public async Task SetPlaybackVolume(string accessToken, HttpClient client, int volume)
        {
            if (0 > volume | volume>100 ) { volume = 50; }
            string url = $"https://api.spotify.com/v1/me/player/volume?volume_percent={volume}";
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }
        public async Task TogglePlaybackShuffle(string accessToken, HttpClient client, bool isShuffled)
        {
            string url = $"https://api.spotify.com/v1/me/player/shuffle?state={isShuffled}";
            await HeaderFormat(client, accessToken);
            await SendPutRequest(client, url);
        }

        public async Task GetRecentlyPlayedTracks(string accessToken, HttpClient client)
        {
            string url = "https://api.spotify.com/v1/me/player/recently-played";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);

        }

        public async Task GetUserQueue(string accessToken, HttpClient client)
        {
            string url = "https://api.spotify.com/v1/me/player/queue";
            await HeaderFormat(client, accessToken);
            await SendGetRequest(client, url);

        }

        public async Task AddItemToQueue(string accessToken, HttpClient client, string itemId, bool isEpisode)
        {
            string url = "";
            if (!isEpisode) {
                url = $"https://api.spotify.com/v1/me/player/queue?uri=spotify%3Atrack%3A{itemId}";

            }
            else
            {
                url = $"https://api.spotify.com/v1/me/player/queue?uri=spotify%3Aepisode%3A{itemId}";

            }
            await HeaderFormat(client, accessToken);
            await SendPostRequest(client, url);

        }



    }
}
