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
    public class LocksTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequest("locks");
            var response = TestHelper.MockConnection().Api.Locks.All();
            AssertResponseListOfLocks(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequest("locks");
            var response = await TestHelper.MockConnection().Api.Locks.AllAsync();
            AssertResponseListOfLocks(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequest("locks/dummy");
            var response = TestHelper.MockConnection().Api.Locks.Show("dummy");
            AssertResponseLockById(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequest("locks/dummy");
            var response = await TestHelper.MockConnection().Api.Locks.ShowAsync("dummy");
            AssertResponseLockById(response);
        }

        [TestMethod]
        public void Search()
        {
            // TODO: missing fixture
            // TestHelper.MockHttpRequest("locks/search");

            // var parameters = new Dictionary<string, string>
            // {
            //     { "lockId", "dummy" }
            // };

            // var response = TestHelper.MockConnection().Api.Locks.Search(parameters);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            // TODO: missing fixture
            //     TestHelper.MockHttpRequest("locks/search");

            //     var parameters = new Dictionary<string, string>
            //     {
            //         { "lockId", "dummy" }
            //     };

            //     var response = await TestHelper.MockConnection().Api.Locks.SearchAsync(parameters);
        }

        private static void AssertResponseListOfLocks(Response<List<Lock>> response)
        {
            Assert.AreEqual(1, response.Meta.Count);
            Assert.AreEqual(1, response.Meta.PageCount);
            Assert.AreEqual(1, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/locks?page=1&limit=1", response.Meta.Self);
            Assert.AreEqual("/api/v2/locks?page=1&limit=1", response.Meta.First);
            Assert.AreEqual("/api/v2/locks?page=1&limit=1", response.Meta.Last);

            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(Lock));
            CollectionAssert.AllItemsAreNotNull(response.Data);
            CollectionAssert.AllItemsAreUnique(response.Data);
            Assert.AreEqual(1, response.Data.Count());
        }

        private static void AssertResponseLockById(Response<Lock> response)
        {
            Assert.AreEqual("dummyLockId", response.Data.LockId);
            Assert.AreEqual("dummySecretHash", response.Data.SecretHash);
            Assert.AreEqual("dummySenderPublicKey", response.Data.SenderPublicKey);
            Assert.AreEqual("dummyRecipientId", response.Data.RecipientId);
            Assert.AreEqual(81911280, response.Data.Timestamp.Epoch);
            Assert.AreEqual(1572012480, response.Data.Timestamp.Unix);
            Assert.AreEqual("2019-10-25T14:08:00.000Z", response.Data.Timestamp.Human);
            Assert.AreEqual(2, response.Data.ExpirationType);
            Assert.AreEqual(6000000, response.Data.ExpirationValue);
            Assert.AreEqual("dummyVendorField", response.Data.VendorField);
        }
    }
}
