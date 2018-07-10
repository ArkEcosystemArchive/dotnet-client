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
