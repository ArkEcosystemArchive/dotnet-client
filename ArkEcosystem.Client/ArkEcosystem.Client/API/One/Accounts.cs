using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public class Accounts : IAccounts
    {
        readonly HttpClient httpClient;

        public Accounts(HttpClient client)
        {
            httpClient = client;
        }

        public JObject All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<JObject> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("accounts/getAllAccounts", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Show(string address)
        {
            return ShowAsync(address).Result;
        }

        public async Task<JObject> ShowAsync(string address)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("address", address);

            var uri = QueryBuilder.Build("accounts", parameters);

            var response = await httpClient.GetStringAsync("accounts");

            return JObject.Parse(response);
        }

        public JObject Count()
        {
            return CountAsync().Result;
        }

        public async Task<JObject> CountAsync()
        {
            var response = await httpClient.GetStringAsync("accounts/count");

            return JObject.Parse(response);
        }

        public JObject Delegates(string address)
        {
            return DelegatesAsync(address).Result;
        }

        public async Task<JObject> DelegatesAsync(string address)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("address", address);

            var uri = QueryBuilder.Build("accounts/delegates", parameters);

            var response = await httpClient.GetStringAsync("accounts/delegates");

            return JObject.Parse(response);
        }

        public JObject Fee()
        {
            return FeeAsync().Result;
        }

        public async Task<JObject> FeeAsync()
        {
            var response = await httpClient.GetStringAsync("accounts/delegates/fee");

            return JObject.Parse(response);
        }

        public JObject Balance(string address)
        {
            return BalanceAsync(address).Result;
        }

        public async Task<JObject> BalanceAsync(string address)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("address", address);

            var uri = QueryBuilder.Build("accounts/getBalance", parameters);

            var response = await httpClient.GetStringAsync("accounts/getBalance");

            return JObject.Parse(response);
        }

        public JObject PublicKey(string address)
        {
            return PublicKeyAsync(address).Result;
        }

        public async Task<JObject> PublicKeyAsync(string address)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("address", address);

            var uri = QueryBuilder.Build("accounts/getPublicKey", parameters);

            var response = await httpClient.GetStringAsync("accounts/getPublicKey");

            return JObject.Parse(response);
        }

        public JObject Top(Dictionary<string, string> parameters = null)
        {
            return TopAsync(parameters).Result;
        }

        public async Task<JObject> TopAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("accounts/top", parameters);

            var response = await httpClient.GetStringAsync("accounts/top");

            return JObject.Parse(response);
        }
    }
}
