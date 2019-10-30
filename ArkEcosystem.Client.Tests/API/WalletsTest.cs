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
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArkEcosystem.Client.API;
using ArkEcosystem.Client.API.Models;

namespace ArkEcosystem.Client.Tests.API
{
    using Api = ArkEcosystem.Client.API.Api;

    [TestClass]
    public class WalletsTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequest("wallets");
            var response = TestHelper.MockConnection().Api.Wallets.All();
            AssertResponseListOfWallets(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequest("wallets");
            var response = await TestHelper.MockConnection().Api.Wallets.AllAsync();
            AssertResponseListOfWallets(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequest("wallets/dummy");
            var response = TestHelper.MockConnection().Api.Wallets.Show("dummy");
            AssertResponseWalletById(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequest("wallets/dummy");
            var response = await TestHelper.MockConnection().Api.Wallets.ShowAsync("dummy");
            AssertResponseWalletById(response);
        }

        [TestMethod]
        public void Locks()
        {
            TestHelper.MockHttpRequest("wallets/dummy/locks");
            var response = TestHelper.MockConnection().Api.Wallets.Locks("dummy");
            AssertResponseWalletLocks(response);
        }

        [TestMethod]
        public async Task LocksAsync()
        {
            TestHelper.MockHttpRequest("wallets/dummy/locks");
            var response = await TestHelper.MockConnection().Api.Wallets.LocksAsync("dummy");
            AssertResponseWalletLocks(response);
        }

        [TestMethod]
        public void Transactions()
        {
            TestHelper.MockHttpRequest("wallets/dummy/transactions");
            var response = TestHelper.MockConnection().Api.Wallets.Transactions("dummy");
            AssertResponseListOfTransactions(response);
        }

        [TestMethod]
        public async Task TransactionsAsync()
        {
            TestHelper.MockHttpRequest("wallets/dummy/transactions");
            var response = await TestHelper.MockConnection().Api.Wallets.TransactionsAsync("dummy");
            AssertResponseListOfTransactions(response);
        }

        [TestMethod]
        public void SentTransactions()
        {
            TestHelper.MockHttpRequest("wallets/dummy/transactions/sent");
            var response = TestHelper.MockConnection().Api.Wallets.SentTransactions("dummy");
            AssertResponseListOfSentTransactions(response);
        }

        [TestMethod]
        public async Task SentTransactionsAsync()
        {
            TestHelper.MockHttpRequest("wallets/dummy/transactions/sent");
            var response = await TestHelper.MockConnection().Api.Wallets.SentTransactionsAsync("dummy");
            AssertResponseListOfSentTransactions(response);
        }

        [TestMethod]
        public void ReceivedTransactions()
        {
            TestHelper.MockHttpRequest("wallets/dummy/transactions/received");
            var response = TestHelper.MockConnection().Api.Wallets.ReceivedTransactions("dummy");
            AssertResponseListOfReceivedTransactions(response);
        }

        [TestMethod]
        public async Task ReceivedTransactionsAsync()
        {
            TestHelper.MockHttpRequest("wallets/dummy/transactions/received");
            var response = await TestHelper.MockConnection().Api.Wallets.ReceivedTransactionsAsync("dummy");
            AssertResponseListOfReceivedTransactions(response);
        }

        [TestMethod]
        public void Votes()
        {
            TestHelper.MockHttpRequest("wallets/dummy/votes");
            var response = TestHelper.MockConnection().Api.Wallets.Votes("dummy");
            AssertResponseListOfVotes(response);
        }

        [TestMethod]
        public async Task VotesAsync()
        {
            TestHelper.MockHttpRequest("wallets/dummy/votes");
            var response = await TestHelper.MockConnection().Api.Wallets.VotesAsync("dummy");
            AssertResponseListOfVotes(response);
        }

        [TestMethod]
        public void Search()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequest("wallets/search");

            // var parameters = new Dictionary<string, string>
            // {
            //     { "username", "dummy" }
            // };

            // var response = TestHelper.MockConnection().Api.Wallets.Search(parameters);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequest("wallets/search");

            // var parameters = new Dictionary<string, string>
            // {
            //     { "username", "dummy" }
            // };

            // var response = await TestHelper.MockConnection().Api.Wallets.SearchAsync(parameters);
        }

        [TestMethod]
        public void Top()
        {
            TestHelper.MockHttpRequest("wallets/top");
            var response = TestHelper.MockConnection().Api.Wallets.Top();
            AssertResponseListOfTopWallets(response);
        }

        [TestMethod]
        public async Task TopAsync()
        {
            TestHelper.MockHttpRequest("wallets/top");
            var response = await TestHelper.MockConnection().Api.Wallets.TopAsync();
            AssertResponseListOfTopWallets(response);
        }

        private static void AssertResponseListOfWallets(Response<List<Wallet>> response)
        {
            Assert.AreEqual(98, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(98, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/wallets?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/wallets?page=1&limit=100", response.Meta.First);
            Assert.AreEqual("/api/v2/wallets?page=1&limit=100", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Wallet));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(98, response.Data.Count());
        }

        private static void AssertResponseWalletById(Response<Wallet> response)
        {
            Assert.AreEqual("AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z", response.Data.Address);
            Assert.AreEqual(null, response.Data.PublicKey);
            Assert.AreEqual(5000000000, response.Data.Balance);
            Assert.AreEqual(false, response.Data.IsDelegate);
        }

        private static void AssertResponseListOfTransactions(Response<List<Transaction>> response)
        {
            Assert.AreEqual(1, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(1, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/wallets/AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z/transactions?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/wallets/AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z/transactions?page=1&limit=100", response.Meta.First);
            Assert.AreEqual("/api/v2/wallets/AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z/transactions?page=1&limit=100", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Transaction));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(1, response.Data.Count());

            Assert.AreEqual("7501bd36fe26b2be047b4441202bb46c492e962ad7f5bbb8aa35f5e9bce8b3ba", response.Data.First().Id);
            Assert.AreEqual("4323350988242714607", response.Data.First().BlockId);
            Assert.AreEqual(0, response.Data.First().Type);
            Assert.AreEqual(5000000000, response.Data.First().Amount);
            Assert.AreEqual(10000000, response.Data.First().Fee);
            Assert.AreEqual("AJPicaX6vmokoK3x8abBMDpi8GMPc7rLiW", response.Data.First().Sender);
            Assert.AreEqual("AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z", response.Data.First().Recipient);
            Assert.AreEqual("304402200db1cfb5c6a9d63176914ec1a6e63954751d7b2b826b1eb235254fb5ea820de602207202a47f9e24a0471aaae0d3e9a792762ebedd65627c8c3a66ae7190529a9c1a", response.Data.First().Signature);
            Assert.AreEqual("TID: 2", response.Data.First().VendorField);
            Assert.AreEqual(3909, response.Data.First().Confirmations);
            Assert.AreEqual(37654646, response.Data.First().Timestamp.Epoch);
            Assert.AreEqual(1527755846, response.Data.First().Timestamp.Unix);
            Assert.AreEqual("2018-05-31T08:37:26Z", response.Data.First().Timestamp.Human);
        }

        private static void AssertResponseListOfSentTransactions(Response<List<Transaction>> response)
        {
            Assert.AreEqual(0, response.Meta.Count);
            Assert.AreEqual(0, response.Meta.PageCount);
            Assert.AreEqual(0, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/wallets/AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z/transactions/sent?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/wallets/AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z/transactions/sent?page=1&limit=100", response.Meta.First);
            Assert.AreEqual(null, response.Meta.Last);
            Assert.AreEqual(0, response.Data.Count());
        }

        private static void AssertResponseListOfReceivedTransactions(Response<List<Transaction>> response)
        {
            Assert.AreEqual(1, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(1, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/wallets/AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z/transactions/received?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/wallets/AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z/transactions/received?page=1&limit=100", response.Meta.First);
            Assert.AreEqual("/api/v2/wallets/AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z/transactions/received?page=1&limit=100", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Transaction));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(1, response.Data.Count());

            Assert.AreEqual("7501bd36fe26b2be047b4441202bb46c492e962ad7f5bbb8aa35f5e9bce8b3ba", response.Data.First().Id);
            Assert.AreEqual("4323350988242714607", response.Data.First().BlockId);
            Assert.AreEqual(0, response.Data.First().Type);
            Assert.AreEqual(5000000000, response.Data.First().Amount);
            Assert.AreEqual(10000000, response.Data.First().Fee);
            Assert.AreEqual("AJPicaX6vmokoK3x8abBMDpi8GMPc7rLiW", response.Data.First().Sender);
            Assert.AreEqual("AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z", response.Data.First().Recipient);
            Assert.AreEqual("304402200db1cfb5c6a9d63176914ec1a6e63954751d7b2b826b1eb235254fb5ea820de602207202a47f9e24a0471aaae0d3e9a792762ebedd65627c8c3a66ae7190529a9c1a", response.Data.First().Signature);
            Assert.AreEqual("TID: 2", response.Data.First().VendorField);
            Assert.AreEqual(3909, response.Data.First().Confirmations);
            Assert.AreEqual(37654646, response.Data.First().Timestamp.Epoch);
            Assert.AreEqual(1527755846, response.Data.First().Timestamp.Unix);
            Assert.AreEqual("2018-05-31T08:37:26Z", response.Data.First().Timestamp.Human);
        }

        private static void AssertResponseListOfVotes(Response<List<Transaction>> response)
        {
            Assert.AreEqual(0, response.Meta.Count);
            Assert.AreEqual(0, response.Meta.PageCount);
            Assert.AreEqual(0, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/wallets/AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z/votes?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/wallets/AFnogpUHmLgnN11ExWQCyngL1RNB9J6i8Z/votes?page=1&limit=100", response.Meta.First);
            Assert.AreEqual(null, response.Meta.Last);
            Assert.AreEqual(0, response.Data.Count());
        }

        private static void AssertResponseListOfTopWallets(Response<List<Wallet>> response)
        {
            Assert.AreEqual(98, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(98, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/wallets/top?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/wallets/top?page=1&limit=100", response.Meta.First);
            Assert.AreEqual("/api/v2/wallets/top?page=1&limit=100", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Wallet));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(98, response.Data.Count());
        }

        private static void AssertResponseWalletLocks(Response<List<Lock>> response)
        {
            Assert.AreEqual(1, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(1, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/wallets/dummy/locks?page=1&limit=1", response.Meta.Self);
            Assert.AreEqual("/api/v2/wallets/dummy/locks?page=1&limit=1", response.Meta.First);
            Assert.AreEqual("/api/v2/wallets/dummy/locks?page=1&limit=1", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Lock));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(1, response.Data.Count());
        }
    }
}
