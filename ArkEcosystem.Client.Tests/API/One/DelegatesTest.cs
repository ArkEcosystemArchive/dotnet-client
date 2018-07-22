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

namespace ArkEcosystem.Client.Tests.API.One
{
    using One = ArkEcosystem.Client.API.One.One;

    [TestClass]
    public class DelegatesTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestOne("delegates");

            var response = TestHelper.MockConnection<One>().Api.Delegates.All();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestOne("delegates");

            var response = await TestHelper.MockConnection<One>().Api.Delegates.AllAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestOne("delegates/get");

            var response = TestHelper.MockConnection<One>().Api.Delegates.Show();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestOne("delegates/get");

            var response = await TestHelper.MockConnection<One>().Api.Delegates.ShowAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Count()
        {
            TestHelper.MockHttpRequestOne("delegates/count");

            var response = TestHelper.MockConnection<One>().Api.Delegates.Count();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task CountAsync()
        {
            TestHelper.MockHttpRequestOne("delegates/count");

            var response = await TestHelper.MockConnection<One>().Api.Delegates.CountAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fee()
        {
            TestHelper.MockHttpRequestOne("delegates/fee");

            var response = TestHelper.MockConnection<One>().Api.Delegates.Fee();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeeAsync()
        {
            TestHelper.MockHttpRequestOne("delegates/fee");

            var response = await TestHelper.MockConnection<One>().Api.Delegates.FeeAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ForgedByAccount()
        {
            TestHelper.MockHttpRequestOne("delegates/forging/getForgedByAccount");

            var response = TestHelper.MockConnection<One>().Api.Delegates.ForgedByAccount("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ForgedByAccountAsync()
        {
            TestHelper.MockHttpRequestOne("delegates/forging/getForgedByAccount");

            var response = await TestHelper.MockConnection<One>().Api.Delegates.ForgedByAccountAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            TestHelper.MockHttpRequestOne("delegates/search");

            var response = TestHelper.MockConnection<One>().Api.Delegates.Search("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            TestHelper.MockHttpRequestOne("delegates/search");

            var response = await TestHelper.MockConnection<One>().Api.Delegates.SearchAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Voters()
        {
            TestHelper.MockHttpRequestOne("delegates/voters");

            var response = TestHelper.MockConnection<One>().Api.Delegates.Voters("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task VotersAsync()
        {
            TestHelper.MockHttpRequestOne("delegates/voters");

            var response = await TestHelper.MockConnection<One>().Api.Delegates.VotersAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void NextForgers()
        {
            TestHelper.MockHttpRequestOne("delegates/getNextForgers");

            var response = TestHelper.MockConnection<One>().Api.Delegates.NextForgers();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task NextForgersAsync()
        {
            TestHelper.MockHttpRequestOne("delegates/getNextForgers");

            var response = await TestHelper.MockConnection<One>().Api.Delegates.NextForgersAsync();

            TestHelper.AssertSuccessResponse(response);
        }
    }
}
