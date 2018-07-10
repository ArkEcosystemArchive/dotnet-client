using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public class Blocks : IBlocks
    {
        readonly HttpClient httpClient;

        public Blocks(HttpClient client)
        {
            httpClient = client;
        }

        public JObject All(Dictionary<string, string> parameters)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<JObject> AllAsync(Dictionary<string, string> parameters)
        {
            var uri = QueryBuilder.Build("blocks", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<JObject> ShowAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("blocks/{0}", id));

            return JObject.Parse(response);
        }

        public JObject Transactions(string id, Dictionary<string, string> parameters = null)
        {
            return TransactionsAsync(id, parameters).Result;
        }

        public async Task<JObject> TransactionsAsync(string id, Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build(string.Format("blocks/{0}/transactions", id), parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Search(Dictionary<string, string> parameters = null)
        {
            return SearchAsync(parameters).Result;
        }

        public async Task<JObject> SearchAsync(Dictionary<string, string> parameters = null)
        {
            var formParams = new FormUrlEncodedContent(parameters);

            var response = await httpClient.PostAsync("blocks/search", formParams);

            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }
    }
}
