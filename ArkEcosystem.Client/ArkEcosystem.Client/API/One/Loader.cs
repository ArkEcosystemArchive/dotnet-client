using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public class Loader : ILoader
    {
        readonly HttpClient httpClient;

        public Loader(HttpClient client)
        {
            httpClient = client;
        }

        public JObject Status()
        {
            return StatusAsync().Result;
        }

        public async Task<JObject> StatusAsync()
        {
            var response = await httpClient.GetStringAsync("loader/status");

            return JObject.Parse(response);
        }

        public JObject Sync()
        {
            return SyncAsync().Result;
        }

        public async Task<JObject> SyncAsync()
        {
            var response = await httpClient.GetStringAsync("loader/status/sync");

            return JObject.Parse(response);
        }

        public JObject AutoConfigure()
        {
            return AutoConfigureAsync().Result;
        }

        public async Task<JObject> AutoConfigureAsync()
        {
            var response = await httpClient.GetStringAsync("loader/autoconfigure");

            return JObject.Parse(response);
        }
    }
}
