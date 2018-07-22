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
    using One = ArkEcosystem.Client.API.One.One;

    [TestClass]
    public class BlocksTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestOne("blocks");

            var response = TestHelper.MockConnection<One>().Api.Blocks.All();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestOne("blocks");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.AllAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestOne("blocks/get");

            var response = TestHelper.MockConnection<One>().Api.Blocks.Show("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestOne("blocks/get");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.ShowAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Epoch()
        {
            TestHelper.MockHttpRequestOne("blocks/getEpoch");

            var response = TestHelper.MockConnection<One>().Api.Blocks.Epoch();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task EpochAsync()
        {
            TestHelper.MockHttpRequestOne("blocks/getEpoch");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.EpochAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fee()
        {
            TestHelper.MockHttpRequestOne("blocks/getFee");

            var response = TestHelper.MockConnection<One>().Api.Blocks.Fee();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeeAsync()
        {
            TestHelper.MockHttpRequestOne("blocks/getFee");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.FeeAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fees()
        {
            TestHelper.MockHttpRequestOne("blocks/getFees");

            var response = TestHelper.MockConnection<One>().Api.Blocks.Fees();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeesAsync()
        {
            TestHelper.MockHttpRequestOne("blocks/getFees");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.FeesAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Height()
        {
            TestHelper.MockHttpRequestOne("blocks/getHeight");

            var response = TestHelper.MockConnection<One>().Api.Blocks.Height();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task HeightAsync()
        {
            TestHelper.MockHttpRequestOne("blocks/getHeight");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.HeightAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Milestone()
        {
            TestHelper.MockHttpRequestOne("blocks/getMilestone");

            var response = TestHelper.MockConnection<One>().Api.Blocks.Milestone();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task MilestoneAsync()
        {
            TestHelper.MockHttpRequestOne("blocks/getMilestone");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.MilestoneAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Nethash()
        {
            TestHelper.MockHttpRequestOne("blocks/getNethash");

            var response = TestHelper.MockConnection<One>().Api.Blocks.Nethash();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task NethashAsync()
        {
            TestHelper.MockHttpRequestOne("blocks/getNethash");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.NethashAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Reward()
        {
            TestHelper.MockHttpRequestOne("blocks/getReward");

            var response = TestHelper.MockConnection<One>().Api.Blocks.Reward();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task RewardAsync()
        {
            TestHelper.MockHttpRequestOne("blocks/getReward");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.RewardAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Status()
        {
            TestHelper.MockHttpRequestOne("blocks/getStatus");

            var response = TestHelper.MockConnection<One>().Api.Blocks.Status();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task StatusAsync()
        {
            TestHelper.MockHttpRequestOne("blocks/getStatus");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.StatusAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Supply()
        {
            TestHelper.MockHttpRequestOne("blocks/getSupply");

            var response = TestHelper.MockConnection<One>().Api.Blocks.Supply();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SupplyAsync()
        {
            TestHelper.MockHttpRequestOne("blocks/getSupply");

            var response = await TestHelper.MockConnection<One>().Api.Blocks.SupplyAsync();

            TestHelper.AssertSuccessResponse(response);
        }
    }
}
