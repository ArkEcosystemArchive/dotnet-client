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

            var response = Helpers.MockConnection(2).Transactions().All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("transactions");

            var response = await Helpers.MockConnection(2).Transactions().AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Create()
        {
            Helpers.MockHttpRequest("transactions");

            var response = Helpers.MockConnection(2).Transactions().Create();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task CreateAsync()
        {
            Helpers.MockHttpRequest("transactions");

            var response = await Helpers.MockConnection(2).Transactions().CreateAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("transactions/{$id}");

            var response = Helpers.MockConnection(2).Transactions().Show();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("transactions/{$id}");

            var response = await Helpers.MockConnection(2).Transactions().ShowAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void AllUnconfirmed()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed");

            var response = Helpers.MockConnection(2).Transactions().AllUnconfirmed();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllUnconfirmedAsync()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed");

            var response = await Helpers.MockConnection(2).Transactions().AllUnconfirmedAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ShowUnconfirmed()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed/{$id}");

            var response = Helpers.MockConnection(2).Transactions().ShowUnconfirmed();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowUnconfirmedAsync()
        {
            Helpers.MockHttpRequest("transactions/unconfirmed/{$id}");

            var response = await Helpers.MockConnection(2).Transactions().ShowUnconfirmedAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            Helpers.MockHttpRequest("transactions/search");

            var response = Helpers.MockConnection(2).Transactions().Search();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            Helpers.MockHttpRequest("transactions/search");

            var response = await Helpers.MockConnection(2).Transactions().SearchAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Types()
        {
            Helpers.MockHttpRequest("transactions/types");

            var response = Helpers.MockConnection(2).Transactions().Types();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TypesAsync()
        {
            Helpers.MockHttpRequest("transactions/types");

            var response = await Helpers.MockConnection(2).Transactions().TypesAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
