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
    public class RoundsTest
    {
        [TestMethod]
        public void Delegates()
        {
            TestHelper.MockHttpRequest("rounds/12345/delegates");
            var response = TestHelper.MockConnection().Api.Rounds.Delegates(12345);
            AssertResponseDelegatesById(response);
        }

        [TestMethod]
        public async Task DelegatesAsync()
        {
            TestHelper.MockHttpRequest("rounds/12345/delegates");
            var response = await TestHelper.MockConnection().Api.Rounds.DelegatesAsync(12345);
            AssertResponseDelegatesById(response);
        }

        private static void AssertResponseDelegatesById(Response<List<RoundDelegate>> response)
        {
            CollectionAssert.AllItemsAreInstancesOfType(response.Data, typeof(RoundDelegate));
            CollectionAssert.AllItemsAreNotNull(response.Data);

            Assert.AreEqual("03287bfebba4c7881a0509717e71b34b63f31e40021c321f89ae04f84be6d6ac37", response.Data[0].PublicKey);
            Assert.AreEqual("245100000000000", response.Data[0].Votes);

            Assert.IsTrue(response.Data.Count() == 1);
        }
    }
}
