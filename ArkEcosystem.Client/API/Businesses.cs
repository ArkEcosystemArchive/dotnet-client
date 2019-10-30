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
    public class Businesses
    {
        readonly HttpClient httpClient;

        public Businesses(HttpClient client)
        {
            httpClient = client;
        }

        public Response<List<Business>> All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<Response<List<Business>>> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("businesses", parameters);
            var response = await httpClient.GetStringAsync(uri);
            return Api.ConvertResponse<List<Business>>(response);
        }

        public Response<Business> Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<Response<Business>> ShowAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("businesses/{0}", id));
            return Api.ConvertResponse<Business>(response);
        }

        public Response<List<Bridgechain>> Bridgechains(string id, Dictionary<string, string> parameters = null)
        {
            return BridgechainsAsync(id, parameters).Result;
        }

        public async Task<Response<List<Bridgechain>>> BridgechainsAsync(string id, Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build(string.Format("businesses/{0}/bridgechains", id), parameters);
            var response = await httpClient.GetStringAsync(uri);
            return Api.ConvertResponse<List<Bridgechain>>(response);
        }

        public Response<List<Business>> Search(Dictionary<string, string> parameters = null)
        {
            return SearchAsync(parameters).Result;
        }

        public async Task<Response<List<Business>>> SearchAsync(Dictionary<string, string> parameters = null)
        {
            var formParams = new FormUrlEncodedContent(parameters);
            var response = await httpClient.PostAsync("businesses/search", formParams);
            return Api.ConvertResponse<List<Business>>(await response.Content.ReadAsStringAsync());
        }
    }
}
