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
using ArkEcosystem.Client.API.Two;
using ArkEcosystem.Client.API.Two.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.Two
{
    using Two = ArkEcosystem.Client.API.Two.Two;

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
            // TODO: missing fixture
            // TestHelper.MockHttpRequestTwo("votes/dummy");
            // var response = TestHelper.MockConnection<Two>().Api.Votes.Show("dummy");
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequestTwo("votes/dummy");
            // svar response = await TestHelper.MockConnection<Two>().Api.Votes.ShowAsync("dummy");
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
    }
}
