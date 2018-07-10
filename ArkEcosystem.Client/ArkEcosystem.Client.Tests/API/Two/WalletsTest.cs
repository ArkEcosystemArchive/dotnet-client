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

            var response = Helpers.MockConnection(2).Wallets().All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("wallets");

            var response = await Helpers.MockConnection(2).Wallets().AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("wallets/{$id}");

            var response = Helpers.MockConnection(2).Wallets().Show();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("wallets/{$id}");

            var response = await Helpers.MockConnection(2).Wallets().ShowAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Transactions()
        {
            Helpers.MockHttpRequest("wallets/{$id}/transactions");

            var response = Helpers.MockConnection(2).Wallets().Transactions();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TransactionsAsync()
        {
            Helpers.MockHttpRequest("wallets/{$id}/transactions");

            var response = await Helpers.MockConnection(2).Wallets().TransactionsAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void SentTransactions()
        {
            Helpers.MockHttpRequest("wallets/{$id}/transactions/sent");

            var response = Helpers.MockConnection(2).Wallets().SentTransactions();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SentTransactionsAsync()
        {
            Helpers.MockHttpRequest("wallets/{$id}/transactions/sent");

            var response = await Helpers.MockConnection(2).Wallets().SentTransactionsAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ReceivedTransactions()
        {
            Helpers.MockHttpRequest("wallets/{$id}/transactions/received");

            var response = Helpers.MockConnection(2).Wallets().ReceivedTransactions();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ReceivedTransactionsAsync()
        {
            Helpers.MockHttpRequest("wallets/{$id}/transactions/received");

            var response = await Helpers.MockConnection(2).Wallets().ReceivedTransactionsAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Votes()
        {
            Helpers.MockHttpRequest("wallets/{$id}/votes");

            var response = Helpers.MockConnection(2).Wallets().Votes();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task VotesAsync()
        {
            Helpers.MockHttpRequest("wallets/{$id}/votes");

            var response = await Helpers.MockConnection(2).Wallets().VotesAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            Helpers.MockHttpRequest("wallets/search");

            var response = Helpers.MockConnection(2).Wallets().Search();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            Helpers.MockHttpRequest("wallets/search");

            var response = await Helpers.MockConnection(2).Wallets().SearchAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Top()
        {
            Helpers.MockHttpRequest("wallets/top");

            var response = Helpers.MockConnection(2).Wallets().Top();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TopAsync()
        {
            Helpers.MockHttpRequest("wallets/top");

            var response = await Helpers.MockConnection(2).Wallets().TopAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
