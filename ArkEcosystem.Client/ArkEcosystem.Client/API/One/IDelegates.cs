using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public interface IDelegates
    {
        JObject All(Dictionary<string, string> parameters = null);
        Task<JObject> AllAsync(Dictionary<string, string> parameters = null);

        JObject Show(Dictionary<string, string> parameters = null);
        Task<JObject> ShowAsync(Dictionary<string, string> parameters = null);

        JObject Fee();
        Task<JObject> FeeAsync();

        JObject ForgedByAccount(string generatorPublicKey);
        Task<JObject> ForgedByAccountAsync(string generatorPublicKey);

        JObject Search(string query);
        Task<JObject> SearchAsync(string query);

        JObject Voters(string publicKey);
        Task<JObject> VotersAsync(string publicKey);

        JObject NextForgers();
        Task<JObject> NextForgersAsync();
    }
}
