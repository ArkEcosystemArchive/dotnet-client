using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public interface IPeers
    {
        JObject All(Dictionary<string, string> parameters = null);
        Task<JObject> AllAsync(Dictionary<string, string> parameters = null);

        JObject Show(string ip, int port);
        Task<JObject> ShowAsync(string ip, int port);

        JObject Version();
        Task<JObject> VersionAsync();
    }
}
