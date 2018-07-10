using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public class Delegates : IDelegates
    {
        readonly HttpClient httpClient;

        public Delegates(HttpClient client)
        {
            httpClient = client;
        }

        public JObject All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<JObject> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("delegates", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<JObject> ShowAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("delegates/{0}", id));

            return JObject.Parse(response);
        }

        public JObject Blocks(string id, Dictionary<string, string> parameters = null)
        {
            return BlocksAsync(id, parameters).Result;
        }

        public async Task<JObject> BlocksAsync(string id, Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build(string.Format("delegates/{0}/blocks", id), parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Voters(string id, Dictionary<string, string> parameters = null)
        {
            return VotersAsync(id, parameters).Result;
        }

        public async Task<JObject> VotersAsync(string id, Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build(string.Format("delegates/{0}/voters", id), parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }
    }
}
