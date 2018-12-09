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
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ArkEcosystem.Client.API.Models;
using ArkEcosystem.Client.Helpers;

namespace ArkEcosystem.Client.API
{
    public class Transactions
    {
        readonly HttpClient httpClient;

        public Transactions(HttpClient client)
        {
            httpClient = client;
        }

        public Response<List<Transaction>> All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<Response<List<Transaction>>> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("transactions", parameters);
            var response = await httpClient.GetStringAsync(uri);
            return Two.ConvertResponse<List<Transaction>>(response);
        }

        public Response<Transaction> Create(Dictionary<string, dynamic> parameters)
        {
            return CreateAsync(parameters).Result;
        }

        public async Task<Response<Transaction>> CreateAsync(Dictionary<string, dynamic> parameters)
        {
            var content = new StringContent(parameters.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("transactions", content);
            return Two.ConvertResponse<Transaction>(await response.Content.ReadAsStringAsync());
        }

        public Response<Transaction> Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<Response<Transaction>> ShowAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("transactions/{0}", id));
            return Two.ConvertResponse<Transaction>(response);
        }

        public Response<List<Transaction>> AllUnconfirmed(Dictionary<string, string> parameters = null)
        {
            return AllUnconfirmedAsync(parameters).Result;
        }

        public async Task<Response<List<Transaction>>> AllUnconfirmedAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("transactions/unconfirmed", parameters);
            var response = await httpClient.GetStringAsync(uri);
            return Two.ConvertResponse<List<Transaction>>(response);
        }

        public Response<List<Transaction>> ShowUnconfirmed(string id)
        {
            return ShowUnconfirmedAsync(id).Result;
        }

        public async Task<Response<List<Transaction>>> ShowUnconfirmedAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("transactions/unconfirmed/{0}", id));
            return Two.ConvertResponse<List<Transaction>>(response);
        }

        public Response<List<Transaction>> Search(Dictionary<string, string> parameters)
        {
            return SearchAsync(parameters).Result;
        }

        public async Task<Response<List<Transaction>>> SearchAsync(Dictionary<string, string> parameters)
        {
            var formParams = new FormUrlEncodedContent(parameters);
            var response = await httpClient.PostAsync("transactions/search", formParams);
            return Two.ConvertResponse<List<Transaction>>(await response.Content.ReadAsStringAsync());
        }

        public Response<TransactionTypes> Types()
        {
            return TypesAsync().Result;
        }

        public async Task<Response<TransactionTypes>> TypesAsync()
        {
            var response = await httpClient.GetStringAsync("transactions/types");
            return Two.ConvertResponse<TransactionTypes>(response);
        }
    }
}
