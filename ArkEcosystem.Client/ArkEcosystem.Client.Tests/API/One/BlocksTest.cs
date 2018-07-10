using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.One
{
    [TestClass]
    public class BlocksTest
    {
        [TestMethod]
        public void All()
        {
            Helpers.MockHttpRequest("blocks");

            var response = Helpers.MockConnection(1).Blocks().All();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            Helpers.MockHttpRequest("blocks");

            var response = await Helpers.MockConnection(1).Blocks().AllAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            Helpers.MockHttpRequest("blocks/get");

            var response = Helpers.MockConnection(1).Blocks().Show("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            Helpers.MockHttpRequest("blocks/get");

            var response = await Helpers.MockConnection(1).Blocks().ShowAsync("dummy");

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Epoch()
        {
            Helpers.MockHttpRequest("blocks/getEpoch");

            var response = Helpers.MockConnection(1).Blocks().Epoch();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task EpochAsync()
        {
            Helpers.MockHttpRequest("blocks/getEpoch");

            var response = await Helpers.MockConnection(1).Blocks().EpochAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fee()
        {
            Helpers.MockHttpRequest("blocks/getFee");

            var response = Helpers.MockConnection(1).Blocks().Fee();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeeAsync()
        {
            Helpers.MockHttpRequest("blocks/getFee");

            var response = await Helpers.MockConnection(1).Blocks().FeeAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Fees()
        {
            Helpers.MockHttpRequest("blocks/getFees");

            var response = Helpers.MockConnection(1).Blocks().Fees();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task FeesAsync()
        {
            Helpers.MockHttpRequest("blocks/getFees");

            var response = await Helpers.MockConnection(1).Blocks().FeesAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Height()
        {
            Helpers.MockHttpRequest("blocks/getHeight");

            var response = Helpers.MockConnection(1).Blocks().Height();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task HeightAsync()
        {
            Helpers.MockHttpRequest("blocks/getHeight");

            var response = await Helpers.MockConnection(1).Blocks().HeightAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Milestone()
        {
            Helpers.MockHttpRequest("blocks/getMilestone");

            var response = Helpers.MockConnection(1).Blocks().Milestone();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task MilestoneAsync()
        {
            Helpers.MockHttpRequest("blocks/getMilestone");

            var response = await Helpers.MockConnection(1).Blocks().MilestoneAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Nethash()
        {
            Helpers.MockHttpRequest("blocks/getNethash");

            var response = Helpers.MockConnection(1).Blocks().Nethash();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task NethashAsync()
        {
            Helpers.MockHttpRequest("blocks/getNethash");

            var response = await Helpers.MockConnection(1).Blocks().NethashAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Reward()
        {
            Helpers.MockHttpRequest("blocks/getReward");

            var response = Helpers.MockConnection(1).Blocks().Reward();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task RewardAsync()
        {
            Helpers.MockHttpRequest("blocks/getReward");

            var response = await Helpers.MockConnection(1).Blocks().RewardAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Status()
        {
            Helpers.MockHttpRequest("blocks/getStatus");

            var response = Helpers.MockConnection(1).Blocks().Status();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task StatusAsync()
        {
            Helpers.MockHttpRequest("blocks/getStatus");

            var response = await Helpers.MockConnection(1).Blocks().StatusAsync();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Supply()
        {
            Helpers.MockHttpRequest("blocks/getSupply");

            var response = Helpers.MockConnection(1).Blocks().Supply();

            Helpers.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task SupplyAsync()
        {
            Helpers.MockHttpRequest("blocks/getSupply");

            var response = await Helpers.MockConnection(1).Blocks().SupplyAsync();

            Helpers.AssertSuccessResponse(response);
        }
    }
}
