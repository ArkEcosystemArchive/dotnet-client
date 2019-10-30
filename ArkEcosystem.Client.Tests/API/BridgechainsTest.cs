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
    public class BridgechainsTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequest("bridgechains");
            var response = TestHelper.MockConnection().Api.Bridgechains.All();
            AssertResponseListOfBridgechains(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequest("bridgechains");
            var response = await TestHelper.MockConnection().Api.Bridgechains.AllAsync();
            AssertResponseListOfBridgechains(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequest("bridgechains/1");
            var response = TestHelper.MockConnection().Api.Bridgechains.Show("1");
            AssertResponseBridgechainById(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequest("bridgechains/1");
            var response = await TestHelper.MockConnection().Api.Bridgechains.ShowAsync("1");
            AssertResponseBridgechainById(response);
        }

        [TestMethod]
        public void Search()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequest("bridgechains/search");

            // var parameters = new Dictionary<string, string>
            // {
            //     { "bridgechainId", "1" }
            // };

            // var response = TestHelper.MockConnection().Api.Bridgechains.Search(parameters);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            // TODO: missing fixture
            //     TestHelper.MockHttpRequest("bridgechains/search");

            //     var parameters = new Dictionary<string, string>
            //     {
            //         { "bridgechainId", "1" }
            //     };

            //     var response = await TestHelper.MockConnection().Api.Brigechains.SearchAsync(parameters);
        }

        private static void AssertResponseListOfBridgechains(Response<List<Bridgechain>> response)
        {
            Assert.AreEqual(1, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(1, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/bridgechains?page=1&limit=1", response.Meta.Self);
            Assert.AreEqual("/api/bridgechains?page=1&limit=1", response.Meta.First);
            Assert.AreEqual("/api/bridgechains?page=1&limit=1", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Bridgechain));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(1, response.Data.Count());
        }

        private static void AssertResponseBridgechainById(Response<Bridgechain> response)
        {
            Assert.AreEqual(1, response.Data.BridgechainId);
            Assert.AreEqual(1, response.Data.BusinessId);
            Assert.AreEqual("dummyName", response.Data.Name);
            Assert.AreEqual(new List<string>() {"1.1.1.1"}, response.Data.SeedNodes);
            Assert.AreEqual("dummyGenesisHash", response.Data.GenesisHash);
            Assert.AreEqual("dummyBridgechainRepository", response.Data.BridgechainRepository);
        }
    }
}
