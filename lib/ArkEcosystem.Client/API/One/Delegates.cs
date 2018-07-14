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
    public class Delegates
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

        public JObject Show(Dictionary<string, string> parameters = null)
        {
            return ShowAsync(parameters).Result;
        }

        public async Task<JObject> ShowAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("delegates/get", parameters);

            var response = await httpClient.GetStringAsync("delegates/get");

            return JObject.Parse(response);
        }

        public JObject Count()
        {
            return CountAsync().Result;
        }

        public async Task<JObject> CountAsync()
        {
            var response = await httpClient.GetStringAsync("delegates/count");

            return JObject.Parse(response);
        }

        public JObject Fee()
        {
            return FeeAsync().Result;
        }

        public async Task<JObject> FeeAsync()
        {
            var response = await httpClient.GetStringAsync("delegates/fee");

            return JObject.Parse(response);
        }

        public JObject ForgedByAccount(string generatorPublicKey)
        {
            return ForgedByAccountAsync(generatorPublicKey).Result;
        }

        public async Task<JObject> ForgedByAccountAsync(string generatorPublicKey)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("generatorPublicKey", generatorPublicKey);

            var uri = QueryBuilder.Build("delegates/forging/getForgedByAccount", parameters);

            var response = await httpClient.GetStringAsync("delegates/forging/getForgedByAccount");

            return JObject.Parse(response);
        }

        public JObject Search(string query)
        {
            return SearchAsync(query).Result;
        }

        public async Task<JObject> SearchAsync(string query)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("query", query);

            var uri = QueryBuilder.Build("delegates/search", parameters);

            var response = await httpClient.GetStringAsync("delegates/search");

            return JObject.Parse(response);
        }

        public JObject Voters(string publicKey)
        {
            return VotersAsync(publicKey).Result;
        }

        public async Task<JObject> VotersAsync(string publicKey)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("publicKey", publicKey);

            var uri = QueryBuilder.Build("delegates/voters", parameters);

            var response = await httpClient.GetStringAsync("delegates/voters");

            return JObject.Parse(response);
        }

        public JObject NextForgers()
        {
            return NextForgersAsync().Result;
        }

        public async Task<JObject> NextForgersAsync()
        {
            var response = await httpClient.GetStringAsync("delegates/getNextForgers");

            return JObject.Parse(response);
        }
    }
}
