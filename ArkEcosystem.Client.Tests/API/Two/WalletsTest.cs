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
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.Two
{
    using Two = ArkEcosystem.Client.API.Two.Two;

    [TestClass]
    public class WalletsTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestTwo("wallets");

            var response = TestHelper.MockConnection<Two>().Api.Wallets.All();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestTwo("wallets");

            var response = await TestHelper.MockConnection<Two>().Api.Wallets.AllAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestTwo("wallets/dummy");

            var response = TestHelper.MockConnection<Two>().Api.Wallets.Show("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestTwo("wallets/dummy");

            var response = await TestHelper.MockConnection<Two>().Api.Wallets.ShowAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Transactions()
        {
            TestHelper.MockHttpRequestTwo("wallets/dummy/transactions");

            var response = TestHelper.MockConnection<Two>().Api.Wallets.Transactions("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TransactionsAsync()
        {
            TestHelper.MockHttpRequestTwo("wallets/dummy/transactions");

            var response = await TestHelper.MockConnection<Two>().Api.Wallets.TransactionsAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void SentTransactions()
        {
            TestHelper.MockHttpRequestTwo("wallets/dummy/transactions/sent");

            var response = TestHelper.MockConnection<Two>().Api.Wallets.SentTransactions("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SentTransactionsAsync()
        {
            TestHelper.MockHttpRequestTwo("wallets/dummy/transactions/sent");

            var response = await TestHelper.MockConnection<Two>().Api.Wallets.SentTransactionsAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ReceivedTransactions()
        {
            TestHelper.MockHttpRequestTwo("wallets/dummy/transactions/received");

            var response = TestHelper.MockConnection<Two>().Api.Wallets.ReceivedTransactions("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ReceivedTransactionsAsync()
        {
            TestHelper.MockHttpRequestTwo("wallets/dummy/transactions/received");

            var response = await TestHelper.MockConnection<Two>().Api.Wallets.ReceivedTransactionsAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Votes()
        {
            TestHelper.MockHttpRequestTwo("wallets/dummy/votes");

            var response = TestHelper.MockConnection<Two>().Api.Wallets.Votes("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task VotesAsync()
        {
            TestHelper.MockHttpRequestTwo("wallets/dummy/votes");

            var response = await TestHelper.MockConnection<Two>().Api.Wallets.VotesAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            TestHelper.MockHttpRequestTwo("wallets/search");

            var parameters = new Dictionary<string, string>
            {
                { "username", "dummy" }
            };

            var response = TestHelper.MockConnection<Two>().Api.Wallets.Search(parameters);

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            TestHelper.MockHttpRequestTwo("wallets/search");

            var parameters = new Dictionary<string, string>
            {
                { "username", "dummy" }
            };

            var response = await TestHelper.MockConnection<Two>().Api.Wallets.SearchAsync(parameters);

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Top()
        {
            TestHelper.MockHttpRequestTwo("wallets/top");

            var response = TestHelper.MockConnection<Two>().Api.Wallets.Top();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TopAsync()
        {
            TestHelper.MockHttpRequestTwo("wallets/top");

            var response = await TestHelper.MockConnection<Two>().Api.Wallets.TopAsync();

            TestHelper.AssertSuccessResponse(response);
        }
    }
}
