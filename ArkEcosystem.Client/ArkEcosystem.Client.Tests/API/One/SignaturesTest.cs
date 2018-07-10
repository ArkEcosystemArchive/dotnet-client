using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.One
{
    [TestClass]
    public class SignaturesTest
    {
        [TestMethod]
        public void Fee()
        {
            Helpers.MockHttpRequest("signatures/fee");

            var response = Helpers.MockConnection(1).Signatures().Fee();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeeAsync()
        {
            Helpers.MockHttpRequest("signatures/fee");

            var response = await Helpers.MockConnection(1).Signatures().FeeAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
