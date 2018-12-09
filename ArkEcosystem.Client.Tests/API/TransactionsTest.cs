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
using ArkEcosystem.Client.API;
using ArkEcosystem.Client.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API
{
    using Two = ArkEcosystem.Client.API.Two;

    [TestClass]
    public class TransactionsTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestTwo("transactions");
            var response = TestHelper.MockConnection<Two>().Api.Transactions.All();
            AssertResponseListOfTransactions(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestTwo("transactions");
            var response = await TestHelper.MockConnection<Two>().Api.Transactions.AllAsync();
            AssertResponseListOfTransactions(response);
        }

        [TestMethod]
        public void Create()
        {
            // TODO: missing fixture
            //     TestHelper.MockHttpRequestTwo("transactions");

            //     var parameters = new Dictionary<string, dynamic>
            //     {
            //         { "amount", 1 }
            //     };

            //     var response = TestHelper.MockConnection<Two>().Api.Transactions.Create(parameters);
        }

        [TestMethod]
        public async Task CreateAsync()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequestTwo("transactions");

            // var parameters = new Dictionary<string, dynamic>
            // {
            //     { "amount", 1 }
            // };

            // var response = await TestHelper.MockConnection<Two>().Api.Transactions.CreateAsync(parameters);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestTwo("transactions/dummy");
            var response = TestHelper.MockConnection<Two>().Api.Transactions.Show("dummy");
            AssertResponseTransactionById(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestTwo("transactions/dummy");
            var response = await TestHelper.MockConnection<Two>().Api.Transactions.ShowAsync("dummy");
            AssertResponseTransactionById(response);
        }

        [TestMethod]
        public void AllUnconfirmed()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequestTwo("transactions/unconfirmed");

            // var response = TestHelper.MockConnection<Two>().Api.Transactions.AllUnconfirmed();
        }

        [TestMethod]
        public async Task AllUnconfirmedAsync()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequestTwo("transactions/unconfirmed");

            // var response = await TestHelper.MockConnection<Two>().Api.Transactions.AllUnconfirmedAsync();
        }

        [TestMethod]
        public void ShowUnconfirmed()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequestTwo("transactions/unconfirmed/dummy");

            // var response = TestHelper.MockConnection<Two>().Api.Transactions.ShowUnconfirmed("dummy");
        }

        [TestMethod]
        public async Task ShowUnconfirmedAsync()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequestTwo("transactions/unconfirmed/dummy");

            // var response = await TestHelper.MockConnection<Two>().Api.Transactions.ShowUnconfirmedAsync("dummy");
        }

        [TestMethod]
        public void Search()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequestTwo("transactions/search");

            // var parameters = new Dictionary<string, string>
            // {
            //     { "amount", "1" }
            // };

            // var response = TestHelper.MockConnection<Two>().Api.Transactions.Search(parameters);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequestTwo("transactions/search");

            // var parameters = new Dictionary<string, string>
            // {
            //     { "amount", "1" }
            // };

            // var response = await TestHelper.MockConnection<Two>().Api.Transactions.SearchAsync(parameters);
        }

        [TestMethod]
        public void Types()
        {
            TestHelper.MockHttpRequestTwo("transactions/types");
            var response = TestHelper.MockConnection<Two>().Api.Transactions.Types();
            AssertResponseTransactionTypes(response);
        }

        [TestMethod]
        public async Task TypesAsync()
        {
            TestHelper.MockHttpRequestTwo("transactions/types");
            var response = await TestHelper.MockConnection<Two>().Api.Transactions.TypesAsync();
            AssertResponseTransactionTypes(response);
        }

        private static void AssertResponseListOfTransactions(Response<List<Transaction>> response)
        {
            Assert.AreEqual(100, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(100, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/transactions?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/transactions?page=1&limit=100", response.Meta.First);
            Assert.AreEqual("/api/v2/transactions?page=1&limit=100", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Transaction));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(100, response.Data.Count());
        }

        private static void AssertResponseTransactionById(Response<Transaction> response)
        {
            Assert.AreEqual("7940dbc750a56b0b15c0e04e339a5b197dd016dbf0b1f50e11200f981ee6d829", response.Data.Id);
            Assert.AreEqual("15906472556606346760", response.Data.BlockId);
            Assert.AreEqual(0, response.Data.Type);
            Assert.AreEqual(5000000000, response.Data.Amount);
            Assert.AreEqual(10000000, response.Data.Fee);
            Assert.AreEqual("AJPicaX6vmokoK3x8abBMDpi8GMPc7rLiW", response.Data.Sender);
            Assert.AreEqual("AUSHS9DrMD21QtuZngxXoQ762PGBVdaKPo", response.Data.Recipient);
            Assert.AreEqual("3044022026f2800f02a5c138beb8bebf738888c2b7387f3973addc3dda793bbd0020b1e80220425d3c5a5875a2cbd88c24a7cd4db79840232e3b518f7204ae4f211248956353", response.Data.Signature);
            Assert.AreEqual("TID: 3", response.Data.VendorField);
            Assert.AreEqual(3886, response.Data.Confirmations);
            Assert.AreEqual(37654830, response.Data.Timestamp.Epoch);
            Assert.AreEqual(1527756030, response.Data.Timestamp.Unix);
            Assert.AreEqual("2018-05-31T08:40:30Z", response.Data.Timestamp.Human);
        }

        private static void AssertResponseTransactionTypes(Response<TransactionTypes> response)
        {
            Assert.AreEqual(0, response.Data.Transfer);
            Assert.AreEqual(1, response.Data.SecondSignature);
            Assert.AreEqual(2, response.Data.DelegateRegistration);
            Assert.AreEqual(3, response.Data.Vote);
            Assert.AreEqual(4, response.Data.MultiSignature);
            Assert.AreEqual(5, response.Data.IPFS);
            Assert.AreEqual(6, response.Data.TimelockTransfer);
            Assert.AreEqual(7, response.Data.MultiPayment);
            Assert.AreEqual(8, response.Data.DelegateResignation);
        }
    }
}
