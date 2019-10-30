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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArkEcosystem.Client.API
{
    public class Locks
    {
        readonly HttpClient httpClient;

        public Locks(HttpClient client)
        {
            httpClient = client;
        }

        public Response<List<Lock>> All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<Response<List<Lock>>> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("locks", parameters);
            var response = await httpClient.GetStringAsync(uri);
            return Api.ConvertResponse<List<Lock>>(response);
        }

        public Response<Lock> Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<Response<Lock>> ShowAsync(string id)
        {
            var response = await httpClient.GetStringAsync(string.Format("locks/{0}", id));
            return Api.ConvertResponse<Lock>(response);
        }

        public Response<List<Lock>> Search(Dictionary<string, string> parameters = null)
        {
            return SearchAsync(parameters).Result;
        }

        public async Task<Response<List<Lock>>> SearchAsync(Dictionary<string, string> parameters = null)
        {
            var formParams = new FormUrlEncodedContent(parameters);
            var response = await httpClient.PostAsync("locks/search", formParams);
            return Api.ConvertResponse<List<Lock>>(await response.Content.ReadAsStringAsync());
        }

        public Response<List<Lock>> Unlocked(List<string> ids, Dictionary<string, string> parameters = null)
        {
            return UnlockedAsync(ids, parameters).Result;
        }

        public async Task<Response<List<Lock>>> UnlockedAsync(List<string> ids, Dictionary<string, string> parameters = null)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var serializedIds = new StringContent(JsonConvert.SerializeObject(ids, settings), Encoding.UTF8, "application/json");

            parameters.add("ids", serializedIds);

            var formParams = new FormUrlEncodedContent(parameters);
            var response = await httpClient.PostAsync("locks/unlocked", formParams);
            return Api.ConvertResponse<List<Lock>>(await response.Content.ReadAsStringAsync());
        }
    }
}
