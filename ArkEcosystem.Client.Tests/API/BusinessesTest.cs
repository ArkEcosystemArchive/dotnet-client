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
    public class BusinessesTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequest("businesses");
            var response = TestHelper.MockConnection().Api.Businesses.All();
            AssertResponseListOfBusinesses(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequest("businesses");
            var response = await TestHelper.MockConnection().Api.Businesses.AllAsync();
            AssertResponseListOfBusinesses(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequest("businesses/1");
            var response = TestHelper.MockConnection().Api.Businesses.Show("1");
            AssertResponseBusinessById(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequest("businesses/1");
            var response = await TestHelper.MockConnection().Api.Businesses.ShowAsync("1");
            AssertResponseBusinessById(response);
        }

        [TestMethod]
        public void Bridgechains()
        {
            TestHelper.MockHttpRequest("businesses/1/bridgechains");
            var response = TestHelper.MockConnection().Api.Businesses.Bridgechains("1");
            AssertResponseBusinessBridgechains(response);
        }

        [TestMethod]
        public async Task BridgechainsAsync()
        {
            TestHelper.MockHttpRequest("businesses/1/bridgechains");
            var response = await TestHelper.MockConnection().Api.Businesses.BridgechainsAsync("1");
            AssertResponseBusinessBridgechains(response);
        }

        [TestMethod]
        public void Search()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequest("businesses/search");

            // var parameters = new Dictionary<string, string>
            // {
            //     { "businessId", "1" }
            // };

            // var response = TestHelper.MockConnection().Api.Businesses.Search(parameters);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            // TODO: missing fixture
            //     TestHelper.MockHttpRequest("businesses/search");

            //     var parameters = new Dictionary<string, string>
            //     {
            //         { "businessId", "1" }
            //     };

            //     var response = await TestHelper.MockConnection().Api.Businesses.SearchAsync(parameters);
        }

        private static void AssertResponseListOfBusinesses(Response<List<Business>> response)
        {
            Assert.AreEqual(1, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(1, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/businesses?page=1&limit=1", response.Meta.Self);
            Assert.AreEqual("/api/businesses?page=1&limit=1", response.Meta.First);
            Assert.AreEqual("/api/businesses?page=1&limit=1", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Business));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(1, response.Data.Count());
        }

        private static void AssertResponseBusinessById(Response<Business> response)
        {
            Assert.AreEqual(1, response.Data.BusinessId);
            Assert.AreEqual("dummyName", response.Data.Name);
            Assert.AreEqual("http://dummy.website", response.Data.Website);
            Assert.AreEqual("dummyVat", response.Data.Vat);
            Assert.AreEqual("dummyRepository", response.Data.Repository);
        }

        private static void AssertResponseBusinessBridgechains(Response<List<Bridgechain>> response)
        {
            Assert.AreEqual(1, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(1, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/businesses/1/bridgechains?page=1&limit=1", response.Meta.Self);
            Assert.AreEqual("/api/businesses/1/bridgechains?page=1&limit=1", response.Meta.First);
            Assert.AreEqual("/api/businesses/1/bridgechains?page=1&limit=1", response.Meta.Last);

            Assert.IsTrue(response.Data.Count() == 0);
        }
    }
}
