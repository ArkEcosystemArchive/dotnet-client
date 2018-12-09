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
using Newtonsoft.Json.Linq;
using ArkEcosystem.Client.API.Models;
using ArkEcosystem.Client.Helpers;

namespace ArkEcosystem.Client.API
{
    public class Blocks
    {
        readonly HttpClient httpClient;

        public Blocks(HttpClient client)
        {
            httpClient = client;
        }

        public Response<List<Block>> All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<Response<List<Block>>> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("blocks", parameters);
            var response = await httpClient.GetStringAsync(uri);
            return Two.ConvertResponse<List<Block>>(response);
        }

        public Response<Block> Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<Response<Block>> ShowAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("blocks/{0}", id));
            return Two.ConvertResponse<Block>(response);
        }

        public Response<List<Transaction>> Transactions(string id, Dictionary<string, string> parameters = null)
        {
            return TransactionsAsync(id, parameters).Result;
        }

        public async Task<Response<List<Transaction>>> TransactionsAsync(string id, Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build(string.Format("blocks/{0}/transactions", id), parameters);
            var response = await httpClient.GetStringAsync(uri);
            return Two.ConvertResponse<List<Transaction>>(response);
        }

        public Response<List<Block>> Search(Dictionary<string, string> parameters = null)
        {
            return SearchAsync(parameters).Result;
        }

        public async Task<Response<List<Block>>> SearchAsync(Dictionary<string, string> parameters = null)
        {
            var formParams = new FormUrlEncodedContent(parameters);
            var response = await httpClient.PostAsync("blocks/search", formParams);
            return Two.ConvertResponse<List<Block>>(await response.Content.ReadAsStringAsync());
        }
    }
}
