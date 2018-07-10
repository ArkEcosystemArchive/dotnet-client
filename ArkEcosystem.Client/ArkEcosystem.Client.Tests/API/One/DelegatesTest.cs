using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.One
{
    [TestClass]
    public class DelegatesTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("delegates");

            var response = Helpers.MockOneConnection().Delegates.All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("delegates");

            var response = await Helpers.MockOneConnection().Delegates.AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("delegates/get");

            var response = Helpers.MockOneConnection().Delegates.Show();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("delegates/get");

            var response = await Helpers.MockOneConnection().Delegates.ShowAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Count()
        {
            Helpers.MockHttpRequest("delegates/count");

            var response = Helpers.MockOneConnection().Delegates.Count();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task CountAsync()
        {
            Helpers.MockHttpRequest("delegates/count");

            var response = await Helpers.MockOneConnection().Delegates.CountAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fee()
        {
            Helpers.MockHttpRequest("delegates/fee");

            var response = Helpers.MockOneConnection().Delegates.Fee();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeeAsync()
        {
            Helpers.MockHttpRequest("delegates/fee");

            var response = await Helpers.MockOneConnection().Delegates.FeeAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void ForgedByAccount()
        {
            Helpers.MockHttpRequest("delegates/forging/getForgedByAccount");

            var response = Helpers.MockOneConnection().Delegates.ForgedByAccount("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ForgedByAccountAsync()
        {
            Helpers.MockHttpRequest("delegates/forging/getForgedByAccount");

            var response = await Helpers.MockOneConnection().Delegates.ForgedByAccountAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Search()
        {
            Helpers.MockHttpRequest("delegates/search");

            var response = Helpers.MockOneConnection().Delegates.Search("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            Helpers.MockHttpRequest("delegates/search");

            var response = await Helpers.MockOneConnection().Delegates.SearchAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Voters()
        {
            Helpers.MockHttpRequest("delegates/voters");

            var response = Helpers.MockOneConnection().Delegates.Voters("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task VotersAsync()
        {
            Helpers.MockHttpRequest("delegates/voters");

            var response = await Helpers.MockOneConnection().Delegates.VotersAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void NextForgers()
        {
            Helpers.MockHttpRequest("delegates/getNextForgers");

            var response = Helpers.MockOneConnection().Delegates.NextForgers();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task NextForgersAsync()
        {
            Helpers.MockHttpRequest("delegates/getNextForgers");

            var response = await Helpers.MockOneConnection().Delegates.NextForgersAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
