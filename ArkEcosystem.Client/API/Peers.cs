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
    public class Peers
    {
        readonly HttpClient httpClient;

        public Peers(HttpClient client)
        {
            httpClient = client;
        }

        public Response<List<Peer>> All()
        {
            return AllAsync().Result;
        }

        public async Task<Response<List<Peer>>> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("peers", parameters);
            var response = await httpClient.GetStringAsync(uri);
            return Two.ConvertResponse<List<Peer>>(response);
        }
        public Response<Peer> Show(string ip)
        {
            return ShowAsync(ip).Result;
        }

        public async Task<Response<Peer>> ShowAsync(string ip)
        {
            var response = await httpClient.GetStringAsync(string.Format("peers/{0}", ip));
            return Two.ConvertResponse<Peer>(response);
        }
    }
}
