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
    public class TransactionsTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("transactions");

            var response = Helpers.MockTwoConnection().Transactions.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("transactions");

            var response = await Helpers.MockTwoConnection().Transactions.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Create()
        {
            Helpers.MockHttpRequest("transactions");

            var parameters = new Dictionary<string, dynamic>
            {
                { "amount", 1 }
            };

            var response = Helpers.MockTwoConnection().Transactions.Create(parameters);

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task CreateAsync()
        {
            Helpers.MockHttpRequest("transactions");

            var parameters = new Dictionary<string, dynamic>
            {
                { "amount", 1 }
            };

            var response = await Helpers.MockTwoConnection().Transactions.CreateAsync(parameters);

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("transactions/dummy");

            var response = Helpers.MockTwoConnection().Transactions.Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("transactions/dummy");

            var response = await Helpers.MockTwoConnection().Transactions.ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void AllUnconfirmed()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed");

            var response = Helpers.MockTwoConnection().Transactions.AllUnconfirmed();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllUnconfirmedAsync()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed");

            var response = await Helpers.MockTwoConnection().Transactions.AllUnconfirmedAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ShowUnconfirmed()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed/dummy");

            var response = Helpers.MockTwoConnection().Transactions.ShowUnconfirmed("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowUnconfirmedAsync()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed/dummy");

            var response = await Helpers.MockTwoConnection().Transactions.ShowUnconfirmedAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            Helpers.MockHttpRequest("transactions/search");

            var parameters = new Dictionary<string, string>
            {
                { "amount", "1" }
            };

            var response = Helpers.MockTwoConnection().Transactions.Search(parameters);

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            Helpers.MockHttpRequest("transactions/search");

            var parameters = new Dictionary<string, string>
            {
                { "amount", "1" }
            };

            var response = await Helpers.MockTwoConnection().Transactions.SearchAsync(parameters);

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Types()
        {
            Helpers.MockHttpRequest("transactions/types");

            var response = Helpers.MockTwoConnection().Transactions.Types();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TypesAsync()
        {
            Helpers.MockHttpRequest("transactions/types");

            var response = await Helpers.MockTwoConnection().Transactions.TypesAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
