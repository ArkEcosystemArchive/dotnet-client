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
    using Api = ArkEcosystem.Client.API.Api;

    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void Configuration()
        {
            TestHelper.MockHttpRequest("node/configuration");
            var response = TestHelper.MockConnection().Api.Node.Configuration();
            AssertResponseNodeConfiguration(response);
        }

        [TestMethod]
        public async Task ConfigurationAsync()
        {
            TestHelper.MockHttpRequest("node/configuration");
            var response = await TestHelper.MockConnection().Api.Node.ConfigurationAsync();
            AssertResponseNodeConfiguration(response);
        }

        [TestMethod]
        public void Crypto()
        {
            TestHelper.MockHttpRequest("node/configuration/crypto");
            var response = TestHelper.MockConnection().Api.Node.Crypto();
            AssertResponseNodeCrypto(response);
        }

        [TestMethod]
        public async Task CryptoAsync()
        {
            TestHelper.MockHttpRequest("node/configuration/crypto");
            var response = await TestHelper.MockConnection().Api.Node.CryptoAsync();
            AssertResponseNodeCrypto(response);
        }

        [TestMethod]
        public void Fees()
        {
            TestHelper.MockHttpRequest("node/fees");
            var response = TestHelper.MockConnection().Api.Node.Fees();
            AssertResponseNodeFees(response);
        }

        [TestMethod]
        public async Task FeesAsync()
        {
            TestHelper.MockHttpRequest("node/fees");
            var response = await TestHelper.MockConnection().Api.Node.FeesAsync();
            AssertResponseNodeFees(response);
        }

        [TestMethod]
        public void Status()
        {
            TestHelper.MockHttpRequest("node/status");
            var response = TestHelper.MockConnection().Api.Node.Status();
            AssertResponseNodeStatus(response);
        }


        [TestMethod]
        public async Task StatusAsync()
        {
            TestHelper.MockHttpRequest("node/status");
            var response = await TestHelper.MockConnection().Api.Node.StatusAsync();
            AssertResponseNodeStatus(response);
        }

        [TestMethod]
        public void Syncing()
        {
            TestHelper.MockHttpRequest("node/syncing");
            var response = TestHelper.MockConnection().Api.Node.Syncing();
            AssertResponseNodeSyncing(response);
        }

        [TestMethod]
        public async Task SyncingAsync()
        {
            TestHelper.MockHttpRequest("node/syncing");
            var response = await TestHelper.MockConnection().Api.Node.SyncingAsync();
            AssertResponseNodeSyncing(response);
        }

        private static void AssertResponseNodeFees(Response<List<FeeStatistics>> response) {
            Assert.AreEqual(7, response.Meta.Days);

            Assert.AreEqual(0, response.Data.First().Type);
            Assert.AreEqual("20000000", response.Data.First().Avg);
            Assert.AreEqual("10000000", response.Data.First().Min);
            Assert.AreEqual("30000000", response.Data.First().Max);
            Assert.AreEqual("40000000", response.Data.First().Sum);
            Assert.IsTrue(response.Data.Count() == 1);
        }

        private static void AssertResponseNodeConfiguration(Response<NodeConfiguration> response)
        {
            Assert.AreEqual("d9acd04bde4234a81addb8482333b4ac906bed7be5a9970ce8ada428bd083192", response.Data.Nethash);
            Assert.AreEqual(1, response.Data.Slip44);
            Assert.AreEqual(170, response.Data.Wif);
            Assert.AreEqual("TARK", response.Data.Token);
            Assert.AreEqual("TѦ", response.Data.Symbol);
            Assert.AreEqual("https://texplorer.ark.io", response.Data.Explorer);
            Assert.AreEqual(23, response.Data.Version);

            var ports = new Dictionary<string, Int16>() {
                { "@arkecosystem/core-p2p", 4000 },
                { "@arkecosystem/core-api", 4003 },
            };
            CollectionAssert.AreEqual(ports, response.Data.Ports);
            Assert.AreEqual(10, response.Data.Constants.Height);
            Assert.AreEqual(0, response.Data.Constants.Reward);
            Assert.AreEqual(51, response.Data.Constants.ActiveDelegates);
            Assert.AreEqual(8, response.Data.Constants.BlockTime);
            Assert.AreEqual(0, response.Data.Constants.Block.Version);
            Assert.AreEqual(500, response.Data.Constants.Block.MaxTransactions);
            Assert.AreEqual(21000000, response.Data.Constants.Block.MaxPayload);
            Assert.AreEqual(false, response.Data.Constants.Block.AcceptExpiredTransactionTimestamps);
            Assert.AreEqual(true, response.Data.Constants.Block.IdFullSha256);
            Assert.AreEqual("2017-03-21T13:00:00.000Z", response.Data.Constants.Epoch);

            Assert.AreEqual(10000000, response.Data.Constants.Fees.StaticFees.Transfer);
            Assert.AreEqual(500000000, response.Data.Constants.Fees.StaticFees.SecondSignature);
            Assert.AreEqual(2500000000, response.Data.Constants.Fees.StaticFees.DelegateRegistration);
            Assert.AreEqual(100000000, response.Data.Constants.Fees.StaticFees.Vote);
            Assert.AreEqual(500000000, response.Data.Constants.Fees.StaticFees.MultiSignature);
            Assert.AreEqual(0, response.Data.Constants.Fees.StaticFees.Ipfs);
            Assert.AreEqual(0, response.Data.Constants.Fees.StaticFees.TimelockTransfer);
            Assert.AreEqual(0, response.Data.Constants.Fees.StaticFees.MultiPayment);
            Assert.AreEqual(2500000000, response.Data.Constants.Fees.StaticFees.DelegateResignation);

            Assert.AreEqual(false, response.Data.Constants.IgnoreInvalidSecondSignatureField);
            Assert.AreEqual(false, response.Data.Constants.IgnoreExpiredTransactions);
            Assert.AreEqual(255, response.Data.Constants.VendorFieldLength);

            Assert.AreEqual(true, response.Data.TransactionPool.DynamicFees.Enabled);
            Assert.AreEqual(1000, response.Data.TransactionPool.DynamicFees.MinFeePool);
            Assert.AreEqual(1000, response.Data.TransactionPool.DynamicFees.MinFeeBroadcast);

            Assert.AreEqual(100, response.Data.TransactionPool.DynamicFees.AddonBytes.Transfer);
            Assert.AreEqual(250, response.Data.TransactionPool.DynamicFees.AddonBytes.SecondSignature);
            Assert.AreEqual(400000, response.Data.TransactionPool.DynamicFees.AddonBytes.DelegateRegistration);
            Assert.AreEqual(100, response.Data.TransactionPool.DynamicFees.AddonBytes.Vote);
            Assert.AreEqual(500, response.Data.TransactionPool.DynamicFees.AddonBytes.MultiSignature);
            Assert.AreEqual(250, response.Data.TransactionPool.DynamicFees.AddonBytes.Ipfs);
            Assert.AreEqual(500, response.Data.TransactionPool.DynamicFees.AddonBytes.TimelockTransfer);
            Assert.AreEqual(500, response.Data.TransactionPool.DynamicFees.AddonBytes.MultiPayment);
            Assert.AreEqual(100, response.Data.TransactionPool.DynamicFees.AddonBytes.DelegateResignation);
        }

        private static void AssertResponseNodeCrypto(Response<NodeCrypto> response)
        {
            // TODO
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
    }
}
