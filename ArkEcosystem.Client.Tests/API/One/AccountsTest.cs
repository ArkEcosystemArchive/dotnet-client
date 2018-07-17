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
            Helpers.MockHttpRequest("accounts/getAllAccounts");

            var response = Helpers.MockConnection<One>().Api.Accounts.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("accounts/getAllAccounts");

            var response = await Helpers.MockConnection<One>().Api.Accounts.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("accounts");

            var response = Helpers.MockConnection<One>().Api.Accounts.Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("accounts");

            var response = await Helpers.MockConnection<One>().Api.Accounts.ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Count()
        {
            Helpers.MockHttpRequest("accounts/count");

            var response = Helpers.MockConnection<One>().Api.Accounts.Count();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task CountAsync()
        {
            Helpers.MockHttpRequest("accounts/count");

            var response = await Helpers.MockConnection<One>().Api.Accounts.CountAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Delegates()
        {
            Helpers.MockHttpRequest("accounts/delegates");

            var response = Helpers.MockConnection<One>().Api.Accounts.Delegates("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task DelegatesAsync()
        {
            Helpers.MockHttpRequest("accounts/delegates");

            var response = await Helpers.MockConnection<One>().Api.Accounts.DelegatesAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fee()
        {
            Helpers.MockHttpRequest("accounts/delegates/fee");

            var response = Helpers.MockConnection<One>().Api.Accounts.Fee();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeeAsync()
        {
            Helpers.MockHttpRequest("accounts/delegates/fee");

            var response = await Helpers.MockConnection<One>().Api.Accounts.FeeAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Balance()
        {
            Helpers.MockHttpRequest("accounts/getBalance");

            var response = Helpers.MockConnection<One>().Api.Accounts.Balance("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task BalanceAsync()
        {
            Helpers.MockHttpRequest("accounts/getBalance");

            var response = await Helpers.MockConnection<One>().Api.Accounts.BalanceAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void PublicKey()
        {
            Helpers.MockHttpRequest("accounts/getPublicKey");

            var response = Helpers.MockConnection<One>().Api.Accounts.PublicKey("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task PublicKeyAsync()
        {
            Helpers.MockHttpRequest("accounts/getPublicKey");

            var response = await Helpers.MockConnection<One>().Api.Accounts.PublicKeyAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Top()
        {
            Helpers.MockHttpRequest("accounts/top");

            var response = Helpers.MockConnection<One>().Api.Accounts.Top();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TopAsync()
        {
            Helpers.MockHttpRequest("accounts/top");

            var response = await Helpers.MockConnection<One>().Api.Accounts.TopAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
