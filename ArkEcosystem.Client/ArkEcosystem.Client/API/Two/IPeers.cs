using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public interface IPeers
    {
        JObject All();
        Task<JObject> AllAsync(Dictionary<string, string> parameters = null);

        JObject Show(string ip);
        Task<JObject> ShowAsync(string ip);
    }
}
