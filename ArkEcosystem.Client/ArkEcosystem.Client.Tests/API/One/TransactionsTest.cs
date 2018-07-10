using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.One
{
    [TestClass]
    public class TransactionsTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("transactions");

            var response = Helpers.MockOneConnection().Transactions.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("transactions");

            var response = await Helpers.MockOneConnection().Transactions.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("transactions/get");

            var response = Helpers.MockOneConnection().Transactions.Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("transactions/get");

            var response = await Helpers.MockOneConnection().Transactions.ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void AllUnconfirmed()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed");

            var response = Helpers.MockOneConnection().Transactions.AllUnconfirmed();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllUnconfirmedAsync()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed");

            var response = await Helpers.MockOneConnection().Transactions.AllUnconfirmedAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ShowUnconfirmed()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed/get");

            var response = Helpers.MockOneConnection().Transactions.ShowUnconfirmed("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowUnconfirmedAsync()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed/get");

            var response = await Helpers.MockOneConnection().Transactions.ShowUnconfirmedAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }
    }
}
