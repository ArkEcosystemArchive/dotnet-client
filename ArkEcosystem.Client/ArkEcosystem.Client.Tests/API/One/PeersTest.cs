using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.One
{
    [TestClass]
    public class PeersTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("peers");

            var response = Helpers.MockOneConnection().Peers.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("peers");

            var response = await Helpers.MockOneConnection().Peers.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("peers/get");

            var response = Helpers.MockOneConnection().Peers.Show("dummy", 1234);

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("peers/get");

            var response = await Helpers.MockOneConnection().Peers.ShowAsync("dummy", 1234);

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Version()
        {
            Helpers.MockHttpRequest("peers/version");

            var response = Helpers.MockOneConnection().Peers.Version();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task VersionAsync()
        {
            Helpers.MockHttpRequest("peers/version");

            var response = await Helpers.MockOneConnection().Peers.VersionAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
