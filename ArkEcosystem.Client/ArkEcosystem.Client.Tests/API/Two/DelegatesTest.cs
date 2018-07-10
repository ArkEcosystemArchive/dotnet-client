using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.Two
{
    [TestClass]
    public class DelegatesTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("delegates");

            var response = Helpers.MockConnection(2).Delegates().All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("delegates");

            var response = await Helpers.MockConnection(2).Delegates().AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("delegates/{$id}");

            var response = Helpers.MockConnection(2).Delegates().Show();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("delegates/{$id}");

            var response = await Helpers.MockConnection(2).Delegates().ShowAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Blocks()
        {
            Helpers.MockHttpRequest("delegates/{$id}/blocks");

            var response = Helpers.MockConnection(2).Delegates().Blocks();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task BlocksAsync()
        {
            Helpers.MockHttpRequest("delegates/{$id}/blocks");

            var response = await Helpers.MockConnection(2).Delegates().BlocksAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Voters()
        {
            Helpers.MockHttpRequest("delegates/{$id}/voters");

            var response = Helpers.MockConnection(2).Delegates().Voters();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task VotersAsync()
        {
            Helpers.MockHttpRequest("delegates/{$id}/voters");

            var response = await Helpers.MockConnection(2).Delegates().VotersAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
