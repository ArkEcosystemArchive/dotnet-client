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
    using Two = ArkEcosystem.Client.API.Two;

    [TestClass]
    public class BlocksTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestTwo("blocks");
            var response = TestHelper.MockConnection<Two>().Api.Blocks.All();
            AssertResponseListOfBlocks(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestTwo("blocks");
            var response = await TestHelper.MockConnection<Two>().Api.Blocks.AllAsync();
            AssertResponseListOfBlocks(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestTwo("blocks/dummy");
            var response = TestHelper.MockConnection<Two>().Api.Blocks.Show("dummy");
            AssertResponseBlockById(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestTwo("blocks/dummy");
            var response = await TestHelper.MockConnection<Two>().Api.Blocks.ShowAsync("dummy");
            AssertResponseBlockById(response);
        }

        [TestMethod]
        public void Transactions()
        {
            TestHelper.MockHttpRequestTwo("blocks/dummy/transactions");
            var response = TestHelper.MockConnection<Two>().Api.Blocks.Transactions("dummy");
            AssertResponseBlockTransactions(response);
        }

        [TestMethod]
        public async Task TransactionsAsync()
        {
            TestHelper.MockHttpRequestTwo("blocks/dummy/transactions");
            var response = await TestHelper.MockConnection<Two>().Api.Blocks.TransactionsAsync("dummy");
            AssertResponseBlockTransactions(response);
        }

        [TestMethod]
        public void Search()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequestTwo("blocks/search");

            // var parameters = new Dictionary<string, string>
            // {
            //     { "id", "dummy" }
            // };

            // var response = TestHelper.MockConnection<Two>().Api.Blocks.Search(parameters);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            // TODO: missing fixture
            //     TestHelper.MockHttpRequestTwo("blocks/search");

            //     var parameters = new Dictionary<string, string>
            //     {
            //         { "id", "dummy" }
            //     };

            //     var response = await TestHelper.MockConnection<Two>().Api.Blocks.SearchAsync(parameters);
        }

        private static void AssertResponseListOfBlocks(Response<List<Block>> response)
        {
            Assert.AreEqual(100, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(100, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/blocks?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/blocks?page=1&limit=100", response.Meta.First);
            Assert.AreEqual("/api/v2/blocks?page=1&limit=100", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Block));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(100, response.Data.Count());
        }

        private static void AssertResponseBlockById(Response<Block> response)
        {
            Assert.AreEqual("13966681514128214060", response.Data.Id);
            Assert.AreEqual(0, response.Data.Version);
            Assert.AreEqual(3643, response.Data.Height);
            Assert.AreEqual("15871980998807129429", response.Data.Previous);
            Assert.AreEqual(0, response.Data.Forged.Reward);
            Assert.AreEqual(0, response.Data.Forged.Fee);
            Assert.AreEqual(0, response.Data.Forged.Total);
            Assert.AreEqual("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", response.Data.Payload.Hash);
            Assert.AreEqual(0, response.Data.Payload.Length);
            Assert.AreEqual("genesis_46", response.Data.Generator.Username);
            Assert.AreEqual("AMfyf9iRjXiKNcLQVTUE9oCESUPzmQ6iUT", response.Data.Generator.Address);
            Assert.AreEqual("034776bd6080a504b0f84f8d66b16af292dc253aa5f4be8b807746a82aa383bd3c", response.Data.Generator.PublicKey);
            Assert.AreEqual("3045022100fd4d6364e196822e8824536a24c85ef7b546f6d6aeba12c933b3ef51406fe452022020595b981eff3f40046b25a7236da06b456d7f431a61190c89a7ab4b684392d2", response.Data.Signature);
            Assert.AreEqual(0, response.Data.Transactions);
            Assert.AreEqual(39386850, response.Data.Timestamp.Epoch);
            Assert.AreEqual(1529488050, response.Data.Timestamp.Unix);
            Assert.AreEqual("2018-06-20T09:47:30Z", response.Data.Timestamp.Human);
        }

        private static void AssertResponseBlockTransactions(Response<List<Transaction>> response)
        {
            Assert.AreEqual(0, response.Meta.Count);
            Assert.AreEqual(0, response.Meta.PageCount);
            Assert.AreEqual(0, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/blocks/13966681514128214060/transactions?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/blocks/13966681514128214060/transactions?page=1&limit=100", response.Meta.First);
            Assert.AreEqual(null, response.Meta.Last);

            Assert.IsTrue(response.Data.Count() == 0);
        }
    }
}
