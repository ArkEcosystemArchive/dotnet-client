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
