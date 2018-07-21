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
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.Two
{
    using Two = ArkEcosystem.Client.API.Two.Two;

    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void Status()
        {
            TestHelper.MockHttpRequestTwo("node/status");

            var response = TestHelper.MockConnection<Two>().Api.Node.Status();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task StatusAsync()
        {
            TestHelper.MockHttpRequestTwo("node/status");

            var response = await TestHelper.MockConnection<Two>().Api.Node.StatusAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Syncing()
        {
            TestHelper.MockHttpRequestTwo("node/syncing");

            var response = TestHelper.MockConnection<Two>().Api.Node.Syncing();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SyncingAsync()
        {
            TestHelper.MockHttpRequestTwo("node/syncing");

            var response = await TestHelper.MockConnection<Two>().Api.Node.SyncingAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Configuration()
        {
            TestHelper.MockHttpRequestTwo("node/configuration");

            var response = TestHelper.MockConnection<Two>().Api.Node.Configuration();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ConfigurationAsync()
        {
            TestHelper.MockHttpRequestTwo("node/configuration");

            var response = await TestHelper.MockConnection<Two>().Api.Node.ConfigurationAsync();

            TestHelper.AssertSuccessResponse(response);
        }
    }
}
