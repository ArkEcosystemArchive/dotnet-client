using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public interface IBlocks
    {
        JObject All(Dictionary<string, string> parameters = null);
        Task<JObject> AllAsync(Dictionary<string, string> parameters = null);

        JObject Epoch();
        Task<JObject> EpochAsync();

        JObject Fee();
        Task<JObject> FeeAsync();

        JObject Fees();
        Task<JObject> FeesAsync();

        JObject Height();
        Task<JObject> HeightAsync();

        JObject Milestone();
        Task<JObject> MilestoneAsync();

        JObject Nethash();
        Task<JObject> NethashAsync();

        JObject Reward();
        Task<JObject> RewardAsync();

        JObject Status();
        Task<JObject> StatusAsync();

        JObject Supply();
        Task<JObject> SupplyAsync();
    }
}
