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

            var response = Helpers.MockTwoConnection().Delegates.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("delegates");

            var response = await Helpers.MockTwoConnection().Delegates.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("delegates/dummy");

            var response = Helpers.MockTwoConnection().Delegates.Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("delegates/dummy");

            var response = await Helpers.MockTwoConnection().Delegates.ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Blocks()
        {
            Helpers.MockHttpRequest("delegates/dummy/blocks");

                var response = Helpers.MockTwoConnection().Delegates.Blocks("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task BlocksAsync()
        {
            Helpers.MockHttpRequest("delegates/dummy/blocks");

                var response = await Helpers.MockTwoConnection().Delegates.BlocksAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Voters()
        {
            Helpers.MockHttpRequest("delegates/dummy/voters");

                var response = Helpers.MockTwoConnection().Delegates.Voters("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task VotersAsync()
        {
            Helpers.MockHttpRequest("delegates/dummy/voters");

                var response = await Helpers.MockTwoConnection().Delegates.VotersAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }
    }
}
