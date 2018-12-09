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
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArkEcosystem.Client.API;
using ArkEcosystem.Client.API.Models;

namespace ArkEcosystem.Client.Tests.API
{
    using Two = ArkEcosystem.Client.API.Two;

    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void Status()
        {
            TestHelper.MockHttpRequestTwo("node/status");
            var response = TestHelper.MockConnection<Two>().Api.Node.Status();
            AssertResponseNodeStatus(response);
        }


        [TestMethod]
        public async Task StatusAsync()
        {
            TestHelper.MockHttpRequestTwo("node/status");
            var response = await TestHelper.MockConnection<Two>().Api.Node.StatusAsync();
            AssertResponseNodeStatus(response);
        }

        [TestMethod]
        public void Syncing()
        {
            TestHelper.MockHttpRequestTwo("node/syncing");
            var response = TestHelper.MockConnection<Two>().Api.Node.Syncing();
            AssertResponseNodeSyncing(response);
        }

        [TestMethod]
        public async Task SyncingAsync()
        {
            TestHelper.MockHttpRequestTwo("node/syncing");
            var response = await TestHelper.MockConnection<Two>().Api.Node.SyncingAsync();
            AssertResponseNodeSyncing(response);
        }

        [TestMethod]
        public void Configuration()
        {
            TestHelper.MockHttpRequestTwo("node/configuration");
            var response = TestHelper.MockConnection<Two>().Api.Node.Configuration();
            AssertResponseNodeConfiguration(response);
        }

        [TestMethod]
        public async Task ConfigurationAsync()
        {
            TestHelper.MockHttpRequestTwo("node/configuration");
            var response = await TestHelper.MockConnection<Two>().Api.Node.ConfigurationAsync();
            AssertResponseNodeConfiguration(response);
        }
        private static void AssertResponseNodeStatus(Response<NodeStatus> response)
        {
            Assert.AreEqual(true, response.Data.Synced);
            Assert.AreEqual(3940, response.Data.Now);
            Assert.AreEqual(0, response.Data.BlocksCount);
        }

        private static void AssertResponseNodeSyncing(Response<NodeSyncing> response)
        {
            Assert.AreEqual(false, response.Data.Syncing);
            Assert.AreEqual(0, response.Data.Blocks);
            Assert.AreEqual(3940, response.Data.Height);
            Assert.AreEqual("17142334154459441029", response.Data.Id);
        }

        private static void AssertResponseNodeConfiguration(Response<NodeConfiguration> response)
        {
            Assert.AreEqual("d9acd04bde4234a81addb8482333b4ac906bed7be5a9970ce8ada428bd083192", response.Data.Nethash);
            Assert.AreEqual("TARK", response.Data.Token);
            Assert.AreEqual("TѦ", response.Data.Symbol);
            Assert.AreEqual("http://texplorer.ark.io", response.Data.Explorer);
            Assert.AreEqual(23, response.Data.Version);

            var ports = new Dictionary<string, Int16>() {
                { "@arkecosystem/core-p2p", 4000},
                { "@arkecosystem/core-api", 4003},
                { "@arkecosystem/core-graphql", 4005}
            };
            CollectionAssert.AreEqual(ports, response.Data.Ports);
            Assert.AreEqual(10, response.Data.Constants.Height);
            Assert.AreEqual(0, response.Data.Constants.Reward);
            Assert.AreEqual(51, response.Data.Constants.ActiveDelegates);
            Assert.AreEqual(8, response.Data.Constants.BlockTime);
            Assert.AreEqual(0, response.Data.Constants.Block.Version);
            Assert.AreEqual(50, response.Data.Constants.Block.MaxTransactions);
            Assert.AreEqual(2097152, response.Data.Constants.Block.MaxPayload);
            Assert.AreEqual("2017-03-21T13:00:00.000Z", response.Data.Constants.Epoch);

            Assert.AreEqual(true, response.Data.Constants.Fees.Dynamic);
            Assert.AreEqual(10000000, response.Data.Constants.Fees.Transfer);
            Assert.AreEqual(500000000, response.Data.Constants.Fees.SecondSignature);
            Assert.AreEqual(2500000000, response.Data.Constants.Fees.DelegateRegistration);
            Assert.AreEqual(100000000, response.Data.Constants.Fees.Vote);
            Assert.AreEqual(500000000, response.Data.Constants.Fees.MultiSignature);
            Assert.AreEqual(0, response.Data.Constants.Fees.IPFS);
            Assert.AreEqual(0, response.Data.Constants.Fees.TimelockTransfer);
            Assert.AreEqual(0, response.Data.Constants.Fees.MultiPayment);
            Assert.AreEqual(0, response.Data.Constants.Fees.DelegateResignation);

            Assert.AreEqual(100, response.Data.Constants.DynamicOffsets.Transfer);
            Assert.AreEqual(250, response.Data.Constants.DynamicOffsets.SecondSignature);
            Assert.AreEqual(500, response.Data.Constants.DynamicOffsets.DelegateRegistration);
            Assert.AreEqual(100, response.Data.Constants.DynamicOffsets.Vote);
            Assert.AreEqual(500, response.Data.Constants.DynamicOffsets.MultiSignature);
            Assert.AreEqual(250, response.Data.Constants.DynamicOffsets.IPFS);
            Assert.AreEqual(500, response.Data.Constants.DynamicOffsets.TimelockTransfer);
            Assert.AreEqual(500, response.Data.Constants.DynamicOffsets.MultiPayment);
            Assert.AreEqual(500, response.Data.Constants.DynamicOffsets.DelegateResignation);

            Assert.AreEqual(0, response.Data.FeeStatistics.First().Type);
            Assert.AreEqual(10000000, response.Data.FeeStatistics.First().Fees.MinFee);
            Assert.AreEqual(10000000, response.Data.FeeStatistics.First().Fees.MaxFee);
            Assert.AreEqual(10000000, response.Data.FeeStatistics.First().Fees.AvgFee);
        }
    }
}
