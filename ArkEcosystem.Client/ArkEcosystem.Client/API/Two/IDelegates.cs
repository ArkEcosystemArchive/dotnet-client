using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public interface IDelegates
    {
        JObject All(Dictionary<string, string> parameters = null);
        Task<JObject> AllAsync(Dictionary<string, string> parameters = null);

        JObject Show(string id);
        Task<JObject> ShowAsync(string id);

        JObject Blocks(string id, Dictionary<string, string> parameters = null);
        Task<JObject> BlocksAsync(string id, Dictionary<string, string> parameters = null);

        JObject Voters(string id, Dictionary<string, string> parameters = null);
        Task<JObject> VotersAsync(string id, Dictionary<string, string> parameters = null);
    }
}
