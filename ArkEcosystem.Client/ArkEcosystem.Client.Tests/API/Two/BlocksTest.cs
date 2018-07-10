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

            var response = Helpers.MockConnection(2).Blocks().All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("blocks");

            var response = await Helpers.MockConnection(2).Blocks().AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("blocks/{$id}");

            var response = Helpers.MockConnection(2).Blocks().Show();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("blocks/{$id}");

            var response = await Helpers.MockConnection(2).Blocks().ShowAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Transactions()
        {
            Helpers.MockHttpRequest("blocks/{$id}/transactions");

            var response = Helpers.MockConnection(2).Blocks().Transactions();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task TransactionsAsync()
        {
            Helpers.MockHttpRequest("blocks/{$id}/transactions");

            var response = await Helpers.MockConnection(2).Blocks().TransactionsAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            Helpers.MockHttpRequest("blocks/search");

            var response = Helpers.MockConnection(2).Blocks().Search();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            Helpers.MockHttpRequest("blocks/search");

            var response = await Helpers.MockConnection(2).Blocks().SearchAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
