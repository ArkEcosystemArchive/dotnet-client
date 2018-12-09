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
    public class DelegatesTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestTwo("delegates");
            var response = TestHelper.MockConnection<Two>().Api.Delegates.All();
            AssertResponseListOfTransactions(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestTwo("delegates");
            var response = await TestHelper.MockConnection<Two>().Api.Delegates.AllAsync();
            AssertResponseListOfTransactions(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestTwo("delegates/dummy");
            var response = TestHelper.MockConnection<Two>().Api.Delegates.Show("dummy");
            AssertResponseDelegateById(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestTwo("delegates/dummy");
            var response = await TestHelper.MockConnection<Two>().Api.Delegates.ShowAsync("dummy");
            AssertResponseDelegateById(response);
        }

        [TestMethod]
        public void Blocks()
        {
            TestHelper.MockHttpRequestTwo("delegates/dummy/blocks");
            var response = TestHelper.MockConnection<Two>().Api.Delegates.Blocks("dummy");
            AssertResponseListOfBlock(response);
        }

        [TestMethod]
        public async Task BlocksAsync()
        {
            TestHelper.MockHttpRequestTwo("delegates/dummy/blocks");
            var response = await TestHelper.MockConnection<Two>().Api.Delegates.BlocksAsync("dummy");
            AssertResponseListOfBlock(response);
        }

        [TestMethod]
        public void Voters()
        {
            TestHelper.MockHttpRequestTwo("delegates/dummy/voters");
            var response = TestHelper.MockConnection<Two>().Api.Delegates.Voters("dummy");
            AssertResponseListOfVoters(response);
        }

        [TestMethod]
        public async Task VotersAsync()
        {
            TestHelper.MockHttpRequestTwo("delegates/dummy/voters");
            var response = await TestHelper.MockConnection<Two>().Api.Delegates.VotersAsync("dummy");
            AssertResponseListOfVoters(response);
        }

        private static void AssertResponseListOfTransactions(Response<List<Delegate>> response)
        {
            Assert.AreEqual(51, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(51, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/delegates?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/delegates?page=1&limit=100", response.Meta.First);
            Assert.AreEqual("/api/v2/delegates?page=1&limit=100", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Delegate));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(51, response.Data.Count());
        }

        private static void AssertResponseDelegateById(Response<Delegate> response)
        {
            Assert.AreEqual("genesis_7", response.Data.Username);
            Assert.AreEqual("AV6GP5qhhsZG6MHb4gShy22doUnVjEKHcN", response.Data.Address);
            Assert.AreEqual("022f2978d57f95c021b9d4bf082b482738ce392bcf6bc213710e7a21504cfeb5a0", response.Data.PublicKey);
            Assert.AreEqual(245098000000000, response.Data.Votes);
            Assert.AreEqual(30, response.Data.Rank);
            Assert.AreEqual(89, response.Data.Blocks.Produced);
            Assert.AreEqual(0, response.Data.Blocks.Missed);
            Assert.AreEqual("8811640842219590295", response.Data.Blocks.Last.Id);
            Assert.AreEqual(39388930, response.Data.Blocks.Last.Timestamp.Epoch);
            Assert.AreEqual(1529490130, response.Data.Blocks.Last.Timestamp.Unix);
            Assert.AreEqual("2018-06-20T10:22:10Z", response.Data.Blocks.Last.Timestamp.Human);
            Assert.AreEqual(new decimal(1.96), response.Data.Production.Approval);
            Assert.AreEqual(100, response.Data.Production.Productivity);
        }

        private static void AssertResponseListOfBlock(Response<List<Block>> response)
        {
            Assert.AreEqual(79, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(79, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/delegates/022f2978d57f95c021b9d4bf082b482738ce392bcf6bc213710e7a21504cfeb5a0/blocks?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/delegates/022f2978d57f95c021b9d4bf082b482738ce392bcf6bc213710e7a21504cfeb5a0/blocks?page=1&limit=100", response.Meta.First);
            Assert.AreEqual("/api/v2/delegates/022f2978d57f95c021b9d4bf082b482738ce392bcf6bc213710e7a21504cfeb5a0/blocks?page=1&limit=100", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Block));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(79, response.Data.Count());
        }

        private static void AssertResponseListOfVoters(Response<List<Wallet>> response)
        {
            Assert.AreEqual(1, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(1, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/delegates/022f2978d57f95c021b9d4bf082b482738ce392bcf6bc213710e7a21504cfeb5a0/voters?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/delegates/022f2978d57f95c021b9d4bf082b482738ce392bcf6bc213710e7a21504cfeb5a0/voters?page=1&limit=100", response.Meta.First);
            Assert.AreEqual("/api/v2/delegates/022f2978d57f95c021b9d4bf082b482738ce392bcf6bc213710e7a21504cfeb5a0/voters?page=1&limit=100", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Wallet));
            Assert.AreEqual(1, response.Data.Count());

            Assert.AreEqual("AV6GP5qhhsZG6MHb4gShy22doUnVjEKHcN", response.Data.First().Address);
            Assert.AreEqual("022f2978d57f95c021b9d4bf082b482738ce392bcf6bc213710e7a21504cfeb5a0", response.Data.First().PublicKey);
            Assert.AreEqual(245098000000000, response.Data.First().Balance);
            Assert.AreEqual(true, response.Data.First().IsDelegate);
        }
    }
}
