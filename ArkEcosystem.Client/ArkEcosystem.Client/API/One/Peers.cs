using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public class Peers : IPeers
    {
        readonly HttpClient httpClient;

        public Peers(HttpClient client)
        {
            httpClient = client;
        }

        public JObject All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<JObject> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("peers", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Show(string ip, int port)
        {
            return ShowAsync(ip, port).Result;
        }

        public async Task<JObject> ShowAsync(string ip, int port)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("ip", ip);
            parameters.Add("port", port.ToString());

            var uri = QueryBuilder.Build("peers/get", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Version()
        {
            return VersionAsync().Result;
        }

        public async Task<JObject> VersionAsync()
        {
            var response = await httpClient.GetStringAsync("peers/version");

            return JObject.Parse(response);
        }
    }
}
