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
    public class AccountsTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestOne("accounts/getAllAccounts");

            var response = TestHelper.MockConnection<One>().Api.Accounts.All();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestOne("accounts/getAllAccounts");

            var response = await TestHelper.MockConnection<One>().Api.Accounts.AllAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestOne("accounts");

            var response = TestHelper.MockConnection<One>().Api.Accounts.Show("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestOne("accounts");

            var response = await TestHelper.MockConnection<One>().Api.Accounts.ShowAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Count()
        {
            TestHelper.MockHttpRequestOne("accounts/count");

            var response = TestHelper.MockConnection<One>().Api.Accounts.Count();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task CountAsync()
        {
            TestHelper.MockHttpRequestOne("accounts/count");

            var response = await TestHelper.MockConnection<One>().Api.Accounts.CountAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Delegates()
        {
            TestHelper.MockHttpRequestOne("accounts/delegates");

            var response = TestHelper.MockConnection<One>().Api.Accounts.Delegates("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task DelegatesAsync()
        {
            TestHelper.MockHttpRequestOne("accounts/delegates");

            var response = await TestHelper.MockConnection<One>().Api.Accounts.DelegatesAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fee()
        {
            TestHelper.MockHttpRequestOne("accounts/delegates/fee");

            var response = TestHelper.MockConnection<One>().Api.Accounts.Fee();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeeAsync()
        {
            TestHelper.MockHttpRequestOne("accounts/delegates/fee");

            var response = await TestHelper.MockConnection<One>().Api.Accounts.FeeAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Balance()
        {
            TestHelper.MockHttpRequestOne("accounts/getBalance");

            var response = TestHelper.MockConnection<One>().Api.Accounts.Balance("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task BalanceAsync()
        {
            TestHelper.MockHttpRequestOne("accounts/getBalance");

            var response = await TestHelper.MockConnection<One>().Api.Accounts.BalanceAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void PublicKey()
        {
            TestHelper.MockHttpRequestOne("accounts/getPublicKey");

            var response = TestHelper.MockConnection<One>().Api.Accounts.PublicKey("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task PublicKeyAsync()
        {
            TestHelper.MockHttpRequestOne("accounts/getPublicKey");

            var response = await TestHelper.MockConnection<One>().Api.Accounts.PublicKeyAsync("dummy");

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Top()
        {
            TestHelper.MockHttpRequestOne("accounts/top");

            var response = TestHelper.MockConnection<One>().Api.Accounts.Top();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TopAsync()
        {
            TestHelper.MockHttpRequestOne("accounts/top");

            var response = await TestHelper.MockConnection<One>().Api.Accounts.TopAsync();

            TestHelper.AssertSuccessResponse(response);
        }
    }
}
