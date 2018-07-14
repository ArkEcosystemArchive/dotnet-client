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
            Helpers.MockHttpRequest("delegates");

            var response = Helpers.MockConnection<One>().Api.Delegates.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("delegates");

            var response = await Helpers.MockConnection<One>().Api.Delegates.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("delegates/get");

            var response = Helpers.MockConnection<One>().Api.Delegates.Show();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("delegates/get");

            var response = await Helpers.MockConnection<One>().Api.Delegates.ShowAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Count()
        {
            Helpers.MockHttpRequest("delegates/count");

            var response = Helpers.MockConnection<One>().Api.Delegates.Count();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task CountAsync()
        {
            Helpers.MockHttpRequest("delegates/count");

            var response = await Helpers.MockConnection<One>().Api.Delegates.CountAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fee()
        {
            Helpers.MockHttpRequest("delegates/fee");

            var response = Helpers.MockConnection<One>().Api.Delegates.Fee();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeeAsync()
        {
            Helpers.MockHttpRequest("delegates/fee");

            var response = await Helpers.MockConnection<One>().Api.Delegates.FeeAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ForgedByAccount()
        {
            Helpers.MockHttpRequest("delegates/forging/getForgedByAccount");

            var response = Helpers.MockConnection<One>().Api.Delegates.ForgedByAccount("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ForgedByAccountAsync()
        {
            Helpers.MockHttpRequest("delegates/forging/getForgedByAccount");

            var response = await Helpers.MockConnection<One>().Api.Delegates.ForgedByAccountAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            Helpers.MockHttpRequest("delegates/search");

            var response = Helpers.MockConnection<One>().Api.Delegates.Search("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            Helpers.MockHttpRequest("delegates/search");

            var response = await Helpers.MockConnection<One>().Api.Delegates.SearchAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Voters()
        {
            Helpers.MockHttpRequest("delegates/voters");

            var response = Helpers.MockConnection<One>().Api.Delegates.Voters("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task VotersAsync()
        {
            Helpers.MockHttpRequest("delegates/voters");

            var response = await Helpers.MockConnection<One>().Api.Delegates.VotersAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void NextForgers()
        {
            Helpers.MockHttpRequest("delegates/getNextForgers");

            var response = Helpers.MockConnection<One>().Api.Delegates.NextForgers();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task NextForgersAsync()
        {
            Helpers.MockHttpRequest("delegates/getNextForgers");

            var response = await Helpers.MockConnection<One>().Api.Delegates.NextForgersAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
