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
    public class BlocksTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("blocks");

            var response = Helpers.MockTwoConnection().Blocks.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("blocks");

            var response = await Helpers.MockTwoConnection().Blocks.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("blocks/dummy");

            var response = Helpers.MockTwoConnection().Blocks.Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("blocks/dummy");

            var response = await Helpers.MockTwoConnection().Blocks.ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Transactions()
        {
            Helpers.MockHttpRequest("blocks/dummy/transactions");

            var response = Helpers.MockTwoConnection().Blocks.Transactions("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TransactionsAsync()
        {
            Helpers.MockHttpRequest("blocks/dummy/transactions");

            var response = await Helpers.MockTwoConnection().Blocks.TransactionsAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            Helpers.MockHttpRequest("blocks/search");

            var parameters = new Dictionary<string, string>
            {
                { "id", "dummy" }
            };

            var response = Helpers.MockTwoConnection().Blocks.Search(parameters);

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            Helpers.MockHttpRequest("blocks/search");

            var parameters = new Dictionary<string, string>
            {
                { "id", "dummy" }
            };

            var response = await Helpers.MockTwoConnection().Blocks.SearchAsync(parameters);

            Helpers.AssertSuccessResponse(response);
        }
    }
}
