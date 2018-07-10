using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public interface IVotes
    {
        JObject All(Dictionary<string, string> parameters = null);
        Task<JObject> AllAsync(Dictionary<string, string> parameters = null);

        JObject Show(string id);
        Task<JObject> ShowAsync(string id);
    }
}
