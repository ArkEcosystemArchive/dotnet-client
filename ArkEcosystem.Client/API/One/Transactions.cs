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

namespace ArkEcosystem.Client.API.One
{
    public class Transactions
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
