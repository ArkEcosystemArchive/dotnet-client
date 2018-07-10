using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.Two
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void Status()
        {
            Helpers.MockHttpRequest("node/status");

            var response = Helpers.MockTwoConnection().Node.Status();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task StatusAsync()
        {
            Helpers.MockHttpRequest("node/status");

            var response = await Helpers.MockTwoConnection().Node.StatusAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Syncing()
        {
            Helpers.MockHttpRequest("node/syncing");

            var response = Helpers.MockTwoConnection().Node.Syncing();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SyncingAsync()
        {
            Helpers.MockHttpRequest("node/syncing");

            var response = await Helpers.MockTwoConnection().Node.SyncingAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Configuration()
        {
            Helpers.MockHttpRequest("node/configuration");

            var response = Helpers.MockTwoConnection().Node.Configuration();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ConfigurationAsync()
        {
            Helpers.MockHttpRequest("node/configuration");

            var response = await Helpers.MockTwoConnection().Node.ConfigurationAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
