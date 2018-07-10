using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
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

        public JObject Create(Dictionary<string, dynamic> parameters)
        {
            return CreateAsync(parameters).Result;
        }

        public async Task<JObject> CreateAsync(Dictionary<string, dynamic> parameters)
        {
            var content = new StringContent(parameters.ToString(), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("transactions", content);

            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }

        public JObject Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<JObject> ShowAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("transactions/{0}", id));

            return JObject.Parse(response);
        }

        public JObject AllUnconfirmed(Dictionary<string, string> parameters = null)
        {
            return AllUnconfirmedAsync(parameters).Result;
        }

        public async Task<JObject> AllUnconfirmedAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("transactions/unconfirmed", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject ShowUnconfirmed(string id)
        {
            return ShowUnconfirmedAsync(id).Result;
        }

        public async Task<JObject> ShowUnconfirmedAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("transactions/unconfirmed/{0}", id));

            return JObject.Parse(response);
        }

        public JObject Search(Dictionary<string, string> parameters)
        {
            return SearchAsync(parameters).Result;
        }

        public async Task<JObject> SearchAsync(Dictionary<string, string> parameters)
        {
            var formParams = new FormUrlEncodedContent(parameters);

            var response = await httpClient.PostAsync("transactions/search", formParams);

            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }

        public JObject Types()
        {
            return TypesAsync().Result;
        }

        public async Task<JObject> TypesAsync()
        {
            var response = await httpClient.GetStringAsync("transactions/types");

            return JObject.Parse(response);
        }
    }
}
