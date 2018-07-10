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
    [TestClass]
    public class WalletsTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("wallets");

            var response = Helpers.MockTwoConnection().Wallets.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("wallets");

            var response = await Helpers.MockTwoConnection().Wallets.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("wallets/dummy");

            var response = Helpers.MockTwoConnection().Wallets.Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("wallets/dummy");

            var response = await Helpers.MockTwoConnection().Wallets.ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Transactions()
        {
            Helpers.MockHttpRequest("wallets/dummy/transactions");

            var response = Helpers.MockTwoConnection().Wallets.Transactions("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TransactionsAsync()
        {
            Helpers.MockHttpRequest("wallets/dummy/transactions");

            var response = await Helpers.MockTwoConnection().Wallets.TransactionsAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void SentTransactions()
        {
            Helpers.MockHttpRequest("wallets/dummy/transactions/sent");

            var response = Helpers.MockTwoConnection().Wallets.SentTransactions("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SentTransactionsAsync()
        {
            Helpers.MockHttpRequest("wallets/dummy/transactions/sent");

            var response = await Helpers.MockTwoConnection().Wallets.SentTransactionsAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ReceivedTransactions()
        {
            Helpers.MockHttpRequest("wallets/dummy/transactions/received");

            var response = Helpers.MockTwoConnection().Wallets.ReceivedTransactions("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ReceivedTransactionsAsync()
        {
            Helpers.MockHttpRequest("wallets/dummy/transactions/received");

            var response = await Helpers.MockTwoConnection().Wallets.ReceivedTransactionsAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Votes()
        {
            Helpers.MockHttpRequest("wallets/dummy/votes");

            var response = Helpers.MockTwoConnection().Wallets.Votes("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task VotesAsync()
        {
            Helpers.MockHttpRequest("wallets/dummy/votes");

            var response = await Helpers.MockTwoConnection().Wallets.VotesAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            Helpers.MockHttpRequest("wallets/search");

            var parameters = new Dictionary<string, string>
            {
                { "username", "dummy" }
            };

            var response = Helpers.MockTwoConnection().Wallets.Search(parameters);

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            Helpers.MockHttpRequest("wallets/search");

            var parameters = new Dictionary<string, string>
            {
                { "username", "dummy" }
            };

            var response = await Helpers.MockTwoConnection().Wallets.SearchAsync(parameters);

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Top()
        {
            Helpers.MockHttpRequest("wallets/top");

            var response = Helpers.MockTwoConnection().Wallets.Top();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TopAsync()
        {
            Helpers.MockHttpRequest("wallets/top");

            var response = await Helpers.MockTwoConnection().Wallets.TopAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
