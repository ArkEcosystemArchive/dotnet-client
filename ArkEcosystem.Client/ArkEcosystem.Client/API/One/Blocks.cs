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
    public class Blocks : IBlocks
    {
        readonly HttpClient httpClient;

        public Blocks (HttpClient client) {
            httpClient = client;
        }

        public JObject All(Dictionary<string, string> parameters = null)
        {
            return AllAsync(parameters).Result;
        }

        public async Task<JObject> AllAsync(Dictionary<string, string> parameters = null)
        {
            var uri = QueryBuilder.Build("blocks", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Show(string id)
        {
            return ShowAsync(id).Result;
        }

        public async Task<JObject> ShowAsync(string id)
        {
            var parameters = new Dictionary<string, string>
            {
                { "id", id }
            };

            var uri = QueryBuilder.Build("blocks/get", parameters);

            var response = await httpClient.GetStringAsync(uri);

            return JObject.Parse(response);
        }

        public JObject Epoch()
        {
            return EpochAsync().Result;
        }

        public async Task<JObject> EpochAsync()
        {
            var response = await httpClient.GetStringAsync("blocks/getEpoch");

            return JObject.Parse(response);
        }

        public JObject Fee()
        {
            return FeeAsync().Result;
        }

        public async Task<JObject> FeeAsync()
        {
            var response = await httpClient.GetStringAsync("blocks/getFee");

            return JObject.Parse(response);
        }

        public JObject Fees()
        {
            return FeesAsync().Result;
        }

        public async Task<JObject> FeesAsync()
        {
            var response = await httpClient.GetStringAsync("blocks/getFees");

            return JObject.Parse(response);
        }

        public JObject Height()
        {
            return HeightAsync().Result;
        }

        public async Task<JObject> HeightAsync()
        {
            var response = await httpClient.GetStringAsync("blocks/getHeight");

            return JObject.Parse(response);
        }

        public JObject Milestone()
        {
            return MilestoneAsync().Result;
        }

        public async Task<JObject> MilestoneAsync()
        {
            var response = await httpClient.GetStringAsync("blocks/getMilestone");

            return JObject.Parse(response);
        }

        public JObject Nethash()
        {
            return NethashAsync().Result;
        }

        public async Task<JObject> NethashAsync()
        {
            var response = await httpClient.GetStringAsync("blocks/getNethash");

            return JObject.Parse(response);
        }

        public JObject Reward()
        {
            return RewardAsync().Result;
        }

        public async Task<JObject> RewardAsync()
        {
            var response = await httpClient.GetStringAsync("blocks/getReward");

            return JObject.Parse(response);
        }

        public JObject Status()
        {
            return StatusAsync().Result;
        }

        public async Task<JObject> StatusAsync()
        {
            var response = await httpClient.GetStringAsync("blocks/getStatus");

            return JObject.Parse(response);
        }

        public JObject Supply()
        {
            return SupplyAsync().Result;
        }

        public async Task<JObject> SupplyAsync()
        {
            var response = await httpClient.GetStringAsync("blocks/getSupply");

            return JObject.Parse(response);
        }
    }
}
