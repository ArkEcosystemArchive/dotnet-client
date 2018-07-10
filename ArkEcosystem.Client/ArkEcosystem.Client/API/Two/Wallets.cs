// Author:
//       Brian Faust <brian@ark.io>
//
// Copyright (c) 2018 Ark Ecosystem <info@ark.io>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
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
