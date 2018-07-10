using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public class Node : INode
    {
        readonly HttpClient httpClient;

        public Node(HttpClient client)
        {
            httpClient = client;
        }

        public JObject Status()
        {
            return StatusAsync().Result;
        }

        public async Task<JObject> StatusAsync()
        {
            var response = await httpClient.GetStringAsync("node/status");

            return JObject.Parse(response);
        }

        public JObject Syncing()
        {
            return SyncingAsync().Result;
        }

        public async Task<JObject> SyncingAsync()
        {
            var response = await httpClient.GetStringAsync("node/syncing");

            return JObject.Parse(response);
        }

        public JObject Configuration()
        {
            return ConfigurationAsync().Result;
        }

        public async Task<JObject> ConfigurationAsync()
        {
            var response = await httpClient.GetStringAsync("node/configuration");

            return JObject.Parse(response);
        }
    }
}
