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
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.One
{
    [TestClass]
    public class BlocksTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("blocks");

            var response = Helpers.MockOneConnection().Blocks.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("blocks");

            var response = await Helpers.MockOneConnection().Blocks.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("blocks/get");

            var response = Helpers.MockOneConnection().Blocks.Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("blocks/get");

            var response = await Helpers.MockOneConnection().Blocks.ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Epoch()
        {
            Helpers.MockHttpRequest("blocks/getEpoch");

            var response = Helpers.MockOneConnection().Blocks.Epoch();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task EpochAsync()
        {
            Helpers.MockHttpRequest("blocks/getEpoch");

            var response = await Helpers.MockOneConnection().Blocks.EpochAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fee()
        {
            Helpers.MockHttpRequest("blocks/getFee");

            var response = Helpers.MockOneConnection().Blocks.Fee();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeeAsync()
        {
            Helpers.MockHttpRequest("blocks/getFee");

            var response = await Helpers.MockOneConnection().Blocks.FeeAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fees()
        {
            Helpers.MockHttpRequest("blocks/getFees");

            var response = Helpers.MockOneConnection().Blocks.Fees();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeesAsync()
        {
            Helpers.MockHttpRequest("blocks/getFees");

            var response = await Helpers.MockOneConnection().Blocks.FeesAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Height()
        {
            Helpers.MockHttpRequest("blocks/getHeight");

            var response = Helpers.MockOneConnection().Blocks.Height();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task HeightAsync()
        {
            Helpers.MockHttpRequest("blocks/getHeight");

            var response = await Helpers.MockOneConnection().Blocks.HeightAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Milestone()
        {
            Helpers.MockHttpRequest("blocks/getMilestone");

            var response = Helpers.MockOneConnection().Blocks.Milestone();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task MilestoneAsync()
        {
            Helpers.MockHttpRequest("blocks/getMilestone");

            var response = await Helpers.MockOneConnection().Blocks.MilestoneAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Nethash()
        {
            Helpers.MockHttpRequest("blocks/getNethash");

            var response = Helpers.MockOneConnection().Blocks.Nethash();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task NethashAsync()
        {
            Helpers.MockHttpRequest("blocks/getNethash");

            var response = await Helpers.MockOneConnection().Blocks.NethashAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Reward()
        {
            Helpers.MockHttpRequest("blocks/getReward");

            var response = Helpers.MockOneConnection().Blocks.Reward();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task RewardAsync()
        {
            Helpers.MockHttpRequest("blocks/getReward");

            var response = await Helpers.MockOneConnection().Blocks.RewardAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Status()
        {
            Helpers.MockHttpRequest("blocks/getStatus");

            var response = Helpers.MockOneConnection().Blocks.Status();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task StatusAsync()
        {
            Helpers.MockHttpRequest("blocks/getStatus");

            var response = await Helpers.MockOneConnection().Blocks.StatusAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Supply()
        {
            Helpers.MockHttpRequest("blocks/getSupply");

            var response = Helpers.MockOneConnection().Blocks.Supply();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SupplyAsync()
        {
            Helpers.MockHttpRequest("blocks/getSupply");

            var response = await Helpers.MockOneConnection().Blocks.SupplyAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
