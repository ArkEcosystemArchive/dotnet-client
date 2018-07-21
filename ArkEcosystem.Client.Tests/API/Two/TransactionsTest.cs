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
    public class TransactionsTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestTwo("transactions");

            var response = TestHelper.MockConnection<Two>().Api.Transactions.All();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestTwo("transactions");

            var response = await TestHelper.MockConnection<Two>().Api.Transactions.AllAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Create()
        {
            TestHelper.MockHttpRequestTwo("transactions");

            var parameters = new Dictionary<string, dynamic>
            {
                { "amount", 1 }
            };

            var response = TestHelper.MockConnection<Two>().Api.Transactions.Create(parameters);

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task CreateAsync()
        {
            TestHelper.MockHttpRequestTwo("transactions");

            var parameters = new Dictionary<string, dynamic>
            {
                { "amount", 1 }
            };

            var response = await TestHelper.MockConnection<Two>().Api.Transactions.CreateAsync(parameters);

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestTwo("transactions/dummy");

            var response = TestHelper.MockConnection<Two>().Api.Transactions.Show("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestTwo("transactions/dummy");

            var response = await TestHelper.MockConnection<Two>().Api.Transactions.ShowAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void AllUnconfirmed()
        {
            TestHelper.MockHttpRequestTwo("transactions/unconfirmed");

            var response = TestHelper.MockConnection<Two>().Api.Transactions.AllUnconfirmed();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllUnconfirmedAsync()
        {
            TestHelper.MockHttpRequestTwo("transactions/unconfirmed");

            var response = await TestHelper.MockConnection<Two>().Api.Transactions.AllUnconfirmedAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ShowUnconfirmed()
        {
            TestHelper.MockHttpRequestTwo("transactions/unconfirmed/dummy");

            var response = TestHelper.MockConnection<Two>().Api.Transactions.ShowUnconfirmed("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowUnconfirmedAsync()
        {
            TestHelper.MockHttpRequestTwo("transactions/unconfirmed/dummy");

            var response = await TestHelper.MockConnection<Two>().Api.Transactions.ShowUnconfirmedAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            TestHelper.MockHttpRequestTwo("transactions/search");

            var parameters = new Dictionary<string, string>
            {
                { "amount", "1" }
            };

            var response = TestHelper.MockConnection<Two>().Api.Transactions.Search(parameters);

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            TestHelper.MockHttpRequestTwo("transactions/search");

            var parameters = new Dictionary<string, string>
            {
                { "amount", "1" }
            };

            var response = await TestHelper.MockConnection<Two>().Api.Transactions.SearchAsync(parameters);

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Types()
        {
            TestHelper.MockHttpRequestTwo("transactions/types");

            var response = TestHelper.MockConnection<Two>().Api.Transactions.Types();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TypesAsync()
        {
            TestHelper.MockHttpRequestTwo("transactions/types");

            var response = await TestHelper.MockConnection<Two>().Api.Transactions.TypesAsync();

            TestHelper.AssertSuccessResponse(response);
        }
    }
}
