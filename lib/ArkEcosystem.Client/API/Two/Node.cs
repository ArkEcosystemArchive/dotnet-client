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
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public class Node
    {
        readonly HttpClient httpClient;

        public Node(HttpClient client)
        {
            httpClient = client;
        }

        public JObject Status()
        {
            return StatusAsync().Result;
        }

        public async Task<JObject> StatusAsync()
        {
            var response = await httpClient.GetStringAsync("node/status");

            return JObject.Parse(response);
        }

        public JObject Syncing()
        {
            return SyncingAsync().Result;
        }

        public async Task<JObject> SyncingAsync()
        {
            var response = await httpClient.GetStringAsync("node/syncing");

            return JObject.Parse(response);
        }

        public JObject Configuration()
        {
            return ConfigurationAsync().Result;
        }

        public async Task<JObject> ConfigurationAsync()
        {
            var response = await httpClient.GetStringAsync("node/configuration");

            return JObject.Parse(response);
        }
    }
}
