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

            var response = Helpers.MockTwoConnection().Votes.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("votes");

            var response = await Helpers.MockTwoConnection().Votes.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("votes/dummy");

            var response = Helpers.MockTwoConnection().Votes.Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("votes/dummy");

            var response = await Helpers.MockTwoConnection().Votes.ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }
    }
}
