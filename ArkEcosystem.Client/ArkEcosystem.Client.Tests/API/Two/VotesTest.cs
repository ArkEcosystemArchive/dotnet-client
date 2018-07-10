using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.Two
{
    [TestClass]
    public class VotesTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("votes");

            var response = Helpers.MockConnection(2).Votes().All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("votes");

            var response = await Helpers.MockConnection(2).Votes().AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("votes/{$id}");

            var response = Helpers.MockConnection(2).Votes().Show();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("votes/{$id}");

            var response = await Helpers.MockConnection(2).Votes().ShowAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
