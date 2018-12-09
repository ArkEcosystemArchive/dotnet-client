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
    using System;
    using Two = ArkEcosystem.Client.API.Two;

    [TestClass]
    public class VotesTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestTwo("votes");
            var response = TestHelper.MockConnection<Two>().Api.Votes.All();
            AssertResponseListOfVotes(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestTwo("votes");
            var response = await TestHelper.MockConnection<Two>().Api.Votes.AllAsync();
            AssertResponseListOfVotes(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestTwo("votes/dummy");
            var response = TestHelper.MockConnection<Two>().Api.Votes.Show("dummy");
            AssertResponseVoteStatus(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestTwo("votes/dummy");
            var response = await TestHelper.MockConnection<Two>().Api.Votes.ShowAsync("dummy");
            AssertResponseVoteStatus(response);
        }

        private static void AssertResponseListOfVotes(Response<List<Transaction>> response)
        {
            Assert.AreEqual(51, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(51, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/votes?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/votes?page=1&limit=100", response.Meta.First);
            Assert.AreEqual("/api/v2/votes?page=1&limit=100", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Transaction));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(51, response.Data.Count());
        }

        private static void AssertResponseVoteStatus(Response<Transaction> response)
        {
            Assert.AreEqual("beb8dd43c640f562704090159154b2742afba7eacada9e8edee447e34e7675c6", response.Data.Id);
            Assert.AreEqual("13661015019049808045", response.Data.BlockId);
            Assert.AreEqual(3, response.Data.Type);
            Assert.AreEqual(0, response.Data.Amount);
            Assert.AreEqual(100000000, response.Data.Fee);
            Assert.AreEqual("DAp7JjULVgqzd4jLofkUyLRovHRPUTQwiZ", response.Data.Sender);
            Assert.AreEqual("DAp7JjULVgqzd4jLofkUyLRovHRPUTQwiZ", response.Data.Recipient);
            Assert.AreEqual("3045022100e9a743c5aa0df427f49af61d35fe617182479f7e8d368ce23b7ec43ab6d269c80220193aafd4ccb3eedbd76ded7ea99f31629013dc3af60540029fe98b274d42d284", response.Data.Signature);
            Assert.IsNotNull(response.Data.Asset); // TODO: update once assert information is strongly typed
            Assert.AreEqual(48189, response.Data.Confirmations);
            Assert.AreEqual(32338609, response.Data.Timestamp.Epoch);
            Assert.AreEqual(1522439809, response.Data.Timestamp.Unix);
            Assert.AreEqual("2018-03-30T19:56:49Z", response.Data.Timestamp.Human);
        }
    }
}
