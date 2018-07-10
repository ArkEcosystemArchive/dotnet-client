using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public class Wallets : IWallets
    {
        readonly HttpClient httpClient;

        public Wallets(HttpClient client)
        {
            httpClient = client;
        }

        public JObject All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<JObject> AllAsync(Dictionary<string, string> parameters = null)
        {
            var response = await httpClient.GetStringAsync("wallets");

            return JObject.Parse(response);
        }

        public JObject Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<JObject> ShowAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("wallets/{0}", id));

            return JObject.Parse(response);
        }

        public JObject Transactions(string id, Dictionary<string, string> parameters = null)
        {
            return TransactionsAsync(id, parameters).Result;
        }

        public async Task<JObject> TransactionsAsync(string id, Dictionary<string, string> parameters = null)
        {
            var response = await httpClient.GetStringAsync(string.Format("wallets/{0}/transactions", id));

            return JObject.Parse(response);
        }

        public JObject SentTransactions(string id, Dictionary<string, string> parameters = null)
        {
            return SentTransactionsAsync(id, parameters).Result;
        }

        public async Task<JObject> SentTransactionsAsync(string id, Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build(string.Format("wallets/{0}/transactions/sent", id), parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject ReceivedTransactions(string id, Dictionary<string, string> parameters = null)
        {
            return ReceivedTransactionsAsync(id, parameters).Result;
        }

        public async Task<JObject> ReceivedTransactionsAsync(string id, Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build(string.Format("wallets/{0}/transactions/received", id), parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Votes(string id, Dictionary<string, string> parameters = null)
        {
            return VotesAsync(id, parameters).Result;
        }

        public async Task<JObject> VotesAsync(string id, Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build(string.Format("wallets/{0}/votes", id), parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Search(Dictionary<string, string> parameters)
        {
            return SearchAsync(parameters).Result;
        }

        public async Task<JObject> SearchAsync(Dictionary<string, string> parameters)
        {
            var formParams = new FormUrlEncodedContent(parameters);

            var response = await httpClient.PostAsync("wallets/search", formParams);

            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }

        public JObject Top(Dictionary<string, string> parameters = null)
        {
            return TopAsync(parameters).Result;
        }

        public async Task<JObject> TopAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("wallets/top", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }
    }
}
