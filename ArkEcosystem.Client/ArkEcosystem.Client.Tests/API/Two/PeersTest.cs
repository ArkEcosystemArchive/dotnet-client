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

            var response = Helpers.MockConnection(2).Peers().All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("peers");

            var response = await Helpers.MockConnection(2).Peers().AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("peers/{$ip}");

            var response = Helpers.MockConnection(2).Peers().Show();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("peers/{$ip}");

            var response = await Helpers.MockConnection(2).Peers().ShowAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
