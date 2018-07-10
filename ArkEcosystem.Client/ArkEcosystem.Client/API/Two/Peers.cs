using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public class Peers : IPeers
    {
        readonly HttpClient httpClient;

        public Peers(HttpClient client)
        {
            httpClient = client;
        }

        public JObject All()
        {
            return AllAsync().Result;
        }

        public async Task<JObject> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("peers", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Show(string ip)
        {
            return ShowAsync(ip).Result;
        }

        public async Task<JObject> ShowAsync(string ip)
        {
            var response = await httpClient.GetStringAsync(string.Format("peers/{0}", ip));

            return JObject.Parse(response);
        }
    }
}
