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
            Assert.AreEqual("10370119864814436559", response.Data.Exceptions.Blocks.First());
            Assert.AreEqual("608c7aeba0895da4517496590896eb325a0b5d367e1b186b1c07d7651a568b9e", response.Data.Exceptions.Transactions.First());

            var outlookTable = new Dictionary<string, string>() {
                { "8324387831264270399", "1000087831264270399" },
            };
            CollectionAssert.AreEqual(outlookTable, response.Data.Exceptions.OutlookTable);

            var transactionIdFixTable = new Dictionary<string, string>() {
                { "ca764c01dd78f93393b02f7f6c4f0c12ed8e7ca26d3098e91d6e461a238a6b33", "80d75c7b90288246199e4a97ba726bad6639595ef92ad7c2bd14fd31563241ab" },
            };
            CollectionAssert.AreEqual(transactionIdFixTable, response.Data.Exceptions.TransactionIdFixTable);

            var wrongTransactionOrder = new Dictionary<string, List<string>>() {
                {
                    "11773170219525190460", new List<string>() {
                        "7a1a43098cd253db395514220f69e3b99afaabb2bfcf5ecfa3b99727b367344b",
                    }
                },
            };
            CollectionAssert.AreEqual(wrongTransactionOrder, response.Data.Exceptions.WrongTransactionOrder);

            Assert.AreEqual("3045022100c442ef265f2a7fa102d61e9a180e335fd17e8e3224307dadf8ac856e569c5c5102201a34cb1302cf4e0887b45784bfbdaf5cfbc44f6d6dad638d56bafa82ec96fd45", response.Data.GenesisBlock.BlockSignature);
            Assert.AreEqual("03a4d147a417376742f9ab78c7c3891574d19376aa62e7bbddceaf12e096e79fe0", response.Data.GenesisBlock.GeneratorPublicKey);
            Assert.AreEqual(1, response.Data.GenesisBlock.Height);
            Assert.AreEqual("4366553906931540162", response.Data.GenesisBlock.Id);
            Assert.AreEqual(1, response.Data.GenesisBlock.NumberOfTransactions);
            Assert.AreEqual("6e84d08bd299ed97c212c886c98a57e36545c8f5d645ca7eeae63a8bd62d8988", response.Data.GenesisBlock.PayloadHash);
            Assert.AreEqual(313052, response.Data.GenesisBlock.PayloadLength);
            Assert.AreEqual(null, response.Data.GenesisBlock.PreviousBlock);
            Assert.AreEqual("0", response.Data.GenesisBlock.Reward);
            Assert.AreEqual(0, response.Data.GenesisBlock.Timestamp);
            Assert.AreEqual("12500000000000004", response.Data.GenesisBlock.TotalAmount);
            Assert.AreEqual("0", response.Data.GenesisBlock.TotalFee);
            Assert.AreEqual(0, response.Data.GenesisBlock.Version);

            Assert.AreEqual("0", response.Data.GenesisBlock.Transactions.First().Amount);
            Assert.IsNotNull(response.Data.GenesisBlock.Transactions.First().Asset);
            Assert.AreEqual("0", response.Data.GenesisBlock.Transactions.First().Fee);
            Assert.AreEqual("44d9d0a3093232b9368a24af90577741df8340b93732db23b90d44f6590d3e42", response.Data.GenesisBlock.Transactions.First().Id);
            Assert.AreEqual("AU9BgcsCBDCkzPyY9EZXqiwukYq4Kor4oX", response.Data.GenesisBlock.Transactions.First().RecipientId);
            Assert.AreEqual("0235d486fea0193cbe77e955ab175b8f6eb9eaf784de689beffbd649989f5d6be3", response.Data.GenesisBlock.Transactions.First().SenderPublicKey);
            Assert.AreEqual("3045022100ed57f27cabdb01f5398b30e63e3372735ee428e17e95de675c37586b6d1a5c12022062a0040ed189a4adac6c3d105e05180f7c74e8c68ca9912b3c60286c2226f3fa", response.Data.GenesisBlock.Transactions.First().Signature);
            Assert.AreEqual(0, response.Data.GenesisBlock.Transactions.First().Timestamp);
            Assert.AreEqual(0, response.Data.GenesisBlock.Transactions.First().Type);

            Assert.AreEqual(51, response.Data.Milestones.First().ActiveDelegates);
            Assert.AreEqual(7, response.Data.Milestones.First().BlockTime);
            Assert.AreEqual("2017-03-21T13:00:00.000Z", response.Data.Milestones.First().Epoch);
            Assert.AreEqual(1, response.Data.Milestones.First().Height);
            Assert.AreEqual(0, response.Data.Milestones.First().Reward);
            Assert.AreEqual(64, response.Data.Milestones.First().VendorFieldLength);

            var block = new Dictionary<string, dynamic>() {
                { "acceptExpiredTransactionTimestamps", true },
                { "maxPayload", 2097152 },
                { "maxTransactions", 50 },
                { "version", 0 },
            };
            CollectionAssert.AreEqual(block, response.Data.Milestones.First().Block);

            var staticFees = new Dictionary<string, long>() {
                { "delegateRegistration", 2500000000 },
                { "delegateResignation", 2500000000 },
                { "ipfs", 0 },
                { "multiPayment", 0 },
                { "multiSignature", 500000000 },
                { "secondSignature", 500000000 },
                { "timelockTransfer", 0 },
                { "transfer", 10000000 },
                { "vote", 100000000 },
            };
            CollectionAssert.AreEqual(staticFees, response.Data.Milestones.First().Fees.StaticFees);

            Assert.AreEqual(7, response.Data.GenesisBlock.Network.Aip20);
            Assert.AreEqual("TARK message:\n", response.Data.GenesisBlock.Network.MessagePrefix);
            Assert.AreEqual("testnet", response.Data.GenesisBlock.Network.Name);
            Assert.AreEqual("d9acd04bde4234a81addb8482333b4ac906bed7be5a9970ce8ada428bd083192", response.Data.GenesisBlock.Network.NetHash);
            Assert.AreEqual(23, response.Data.GenesisBlock.Network.PubKeyHash);
            Assert.AreEqual(111, response.Data.GenesisBlock.Network.Slip44);
            Assert.AreEqual(170, response.Data.GenesisBlock.Network.Wif);

            var bip = new Dictionary<string, long>() {
                { "private", 46089520 },
                { "public", 46090600 },
            };
            CollectionAssert.AreEqual(bip, response.Data.Network.Bip32);

            var client = new Dictionary<string, string>() {
                { "explorer", "https://texplorer.ark.io" },
                { "symbol", "TѦ" },
                { "token", "TARK" },
            };
            CollectionAssert.AreEqual(client, response.Data.Network.Client);
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
