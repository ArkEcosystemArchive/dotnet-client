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

            var response = Helpers.MockConnection(2).Node().Status();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task StatusAsync()
        {
            Helpers.MockHttpRequest("node/status");

            var response = await Helpers.MockConnection(2).Node().StatusAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Syncing()
        {
            Helpers.MockHttpRequest("node/syncing");

            var response = Helpers.MockConnection(2).Node().Syncing();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SyncingAsync()
        {
            Helpers.MockHttpRequest("node/syncing");

            var response = await Helpers.MockConnection(2).Node().SyncingAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Configuration()
        {
            Helpers.MockHttpRequest("node/configuration");

            var response = Helpers.MockConnection(2).Node().Configuration();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ConfigurationAsync()
        {
            Helpers.MockHttpRequest("node/configuration");

            var response = await Helpers.MockConnection(2).Node().ConfigurationAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
