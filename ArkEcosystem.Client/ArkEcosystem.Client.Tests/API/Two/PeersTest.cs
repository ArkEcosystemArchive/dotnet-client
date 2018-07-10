using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.Two
{
    [TestClass]
    public class PeersTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("peers");

            var response = Helpers.MockTwoConnection().Peers.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("peers");

            var response = await Helpers.MockTwoConnection().Peers.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("peers/dummy");

            var response = Helpers.MockTwoConnection().Peers.Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("peers/dummy");

            var response = await Helpers.MockTwoConnection().Peers.ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }
    }
}
