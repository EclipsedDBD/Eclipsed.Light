using Eclipsed.Light.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipsed.Light.Classes
{
    public static class Rest
    {
        public static async Task<RestResponse> GetMarketFileHashes()
        {
            var client = new RestClient($"https://{Globals.Domain}");
            var request = new RestRequest("/api/light/CheckMarketFiles");
            request.Method = Method.Get;

            var response = await client.ExecuteAsync(request);
            return response;
        }

        public static async Task<RestResponse> GetMarketFile(string marketfile)
        {
            var client = new RestClient($"https://{Globals.Domain}");
            var request = new RestRequest($"/api/light/MarketFile/{marketfile}");
            request.Method = Method.Get;

            var response = await client.ExecuteAsync(request);
            return response;
        }

        public static async Task<RestResponse> HeadMusic()
        {
            var client = new RestClient($"https://storage.eclipsed.top");
            var request = new RestRequest($"/music/unlocker_music.mp3");
            request.Method = Method.Head;

            var response = await client.ExecuteAsync(request);
            return response;
        }

        public static async Task<RestResponse> GetMusic()
        {
            var client = new RestClient($"https://storage.eclipsed.top");
            var request = new RestRequest($"/music/unlocker_music.mp3");
            request.Method = Method.Get;

            var response = await client.ExecuteAsync(request);
            return response;
        }
    }
}
