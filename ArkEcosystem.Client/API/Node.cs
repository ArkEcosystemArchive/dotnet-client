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
    public class Node
    {
        readonly HttpClient httpClient;

        public Node(HttpClient client)
        {
            httpClient = client;
        }

        public Response<NodeConfiguration> Configuration()
        {
            return ConfigurationAsync().Result;
        }

        public async Task<Response<NodeConfiguration>> ConfigurationAsync()
        {
            var response = await httpClient.GetStringAsync("node/configuration");
            return Api.ConvertResponse<NodeConfiguration>(response);
        }

        public Response<NodeCrypto> Crypto()
        {
            return CryptoAsync().Result;
        }

        public async Task<Response<NodeCrypto>> CryptoAsync()
        {
            var response = await httpClient.GetStringAsync("node/configuration/crypto");
            return Api.ConvertResponse<NodeCrypto>(response);
        }

        public Response<List<FeeStatistics>> Fees()
        {
            return FeesAsync().Result;
        }

        public async Task<Response<List<FeeStatistics>>> FeesAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("node/fees", parameters);
            var response = await httpClient.GetStringAsync(uri);
            return Api.ConvertResponse<List<FeeStatistics>>(response);
        }

        public Response<NodeStatus> Status()
        {
            return StatusAsync().Result;
        }

        public async Task<Response<NodeStatus>> StatusAsync()
        {
            var response = await httpClient.GetStringAsync("node/status");
            return Api.ConvertResponse<NodeStatus>(response);
        }

        public Response<NodeSyncing> Syncing()
        {
            return SyncingAsync().Result;
        }

        public async Task<Response<NodeSyncing>> SyncingAsync()
        {
            var response = await httpClient.GetStringAsync("node/syncing");
            return Api.ConvertResponse<NodeSyncing>(response);
        }
    }
}
