using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.One
{
    [TestClass]
    public class LoaderTest
    {
        [TestMethod]
        public void Status()
        {
            Helpers.MockHttpRequest("loader/status");

            var response = Helpers.MockOneConnection().Loader.Status();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task StatusAsync()
        {
            Helpers.MockHttpRequest("loader/status");

            var response = await Helpers.MockOneConnection().Loader.StatusAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Sync()
        {
            Helpers.MockHttpRequest("loader/status/sync");

            var response = Helpers.MockOneConnection().Loader.Sync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SyncAsync()
        {
            Helpers.MockHttpRequest("loader/status/sync");

            var response = await Helpers.MockOneConnection().Loader.SyncAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void AutoConfigure()
        {
            Helpers.MockHttpRequest("loader/autoconfigure");

            var response = Helpers.MockOneConnection().Loader.AutoConfigure();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AutoConfigureAsync()
        {
            Helpers.MockHttpRequest("loader/autoconfigure");

            var response = await Helpers.MockOneConnection().Loader.AutoConfigureAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
