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
