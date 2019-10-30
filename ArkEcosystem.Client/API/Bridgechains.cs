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
    public class Bridgechains
    {
        readonly HttpClient httpClient;

        public Bridgechains(HttpClient client)
        {
            httpClient = client;
        }

        public Response<List<Bridgechain>> All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<Response<List<Bridgechain>>> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("bridgechains", parameters);
            var response = await httpClient.GetStringAsync(uri);
            return Api.ConvertResponse<List<Bridgechain>>(response);
        }

        public Response<Bridgechain> Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<Response<Bridgechain>> ShowAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("bridgechains/{0}", id));
            return Api.ConvertResponse<Bridgechain>(response);
        }

        public Response<List<Bridgechain>> Search(Dictionary<string, string> parameters = null)
        {
            return SearchAsync(parameters).Result;
        }

        public async Task<Response<List<Bridgechain>>> SearchAsync(Dictionary<string, string> parameters = null)
        {
            var formParams = new FormUrlEncodedContent(parameters);
            var response = await httpClient.PostAsync("bridgechains/search", formParams);
            return Api.ConvertResponse<List<Bridgechain>>(await response.Content.ReadAsStringAsync());
        }
    }
}
