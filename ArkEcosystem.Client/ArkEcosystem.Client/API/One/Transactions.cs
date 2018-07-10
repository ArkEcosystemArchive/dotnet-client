using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public class Transactions : ITransactions
    {
        readonly HttpClient httpClient;

        public Transactions(HttpClient client)
        {
            httpClient = client;
        }

        public JObject All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<JObject> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("transactions", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<JObject> ShowAsync(string id)
        {
            var response = await httpClient.GetStringAsync("transactions/get");

            return JObject.Parse(response);
        }

        public JObject AllUnconfirmed(Dictionary<string, string> parameters = null)
        {
            return AllUnconfirmedAsync(parameters).Result;
        }

        public async Task<JObject> AllUnconfirmedAsync(Dictionary<string, string> parameters = null)
        {
            var uri =  QueryBuilder.Build("transactions/unconfirmed", parameters);

            var response = await httpClient.GetStringAsync("transactions/unconfirmed");

            return JObject.Parse(response);
        }

        public JObject ShowUnconfirmed(string id)
        {
            return ShowUnconfirmedAsync(id).Result;
        }

        public async Task<JObject> ShowUnconfirmedAsync(string id)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("id", id);

            var uri =  QueryBuilder.Build("transactions/unconfirmed/get", parameters);

            var response = await httpClient.GetStringAsync("transactions/unconfirmed/get");

            return JObject.Parse(response);
        }
    }
}
