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
    using System;
    using Two = ArkEcosystem.Client.API.Two;

    [TestClass]
    public class PeersTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestTwo("peers");
            var response = TestHelper.MockConnection<Two>().Api.Peers.All();
            AssertResponseListOfPeers(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestTwo("peers");
            var response = await TestHelper.MockConnection<Two>().Api.Peers.AllAsync();
            AssertResponseListOfPeers(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestTwo("peers/1.2.3.4");
            var response = TestHelper.MockConnection<Two>().Api.Peers.Show("1.2.3.4");
            AssertResponsePeerStatus(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestTwo("peers/1.2.3.4");
            var response = await TestHelper.MockConnection<Two>().Api.Peers.ShowAsync("1.2.3.4");
            AssertResponsePeerStatus(response);
        }

        private static void AssertResponseListOfPeers(Response<List<Peer>> response)
        {
            Assert.AreEqual(0, response.Meta.Count);
            Assert.AreEqual(0, response.Meta.PageCount);
            Assert.AreEqual(0, response.Meta.TotalCount);
            Assert.AreEqual(null, response.Meta.Next);
            Assert.AreEqual(null, response.Meta.Previous);
            Assert.AreEqual("/api/v2/peers?page=1&limit=100", response.Meta.Self);
            Assert.AreEqual("/api/v2/peers?page=1&limit=100", response.Meta.First);
            Assert.AreEqual(null, response.Meta.Last);

            Assert.IsTrue(response.Data.Count() == 0);
        }

        private static void AssertResponsePeerStatus(Response<Peer> response)
        {
            Assert.AreEqual("1.2.3.4", response.Data.Ip);
            Assert.AreEqual(4002, response.Data.Port);
            Assert.AreEqual("1.1.1", response.Data.Version);
            Assert.AreEqual(987654, response.Data.Height);
            Assert.AreEqual("OK", response.Data.Status);
            Assert.AreEqual("linux", response.Data.OS);
            Assert.AreEqual(355, response.Data.Latency);
        }
    }
}
