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
    public class TransactionsTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("transactions");

            var response = Helpers.MockConnection<One>().Api.Transactions.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("transactions");

            var response = await Helpers.MockConnection<One>().Api.Transactions.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("transactions/get");

            var response = Helpers.MockConnection<One>().Api.Transactions.Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("transactions/get");

            var response = await Helpers.MockConnection<One>().Api.Transactions.ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void AllUnconfirmed()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed");

            var response = Helpers.MockConnection<One>().Api.Transactions.AllUnconfirmed();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllUnconfirmedAsync()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed");

            var response = await Helpers.MockConnection<One>().Api.Transactions.AllUnconfirmedAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ShowUnconfirmed()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed/get");

            var response = Helpers.MockConnection<One>().Api.Transactions.ShowUnconfirmed("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowUnconfirmedAsync()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed/get");

            var response = await Helpers.MockConnection<One>().Api.Transactions.ShowUnconfirmedAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }
    }
}
