using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public interface ILoader
    {
        JObject Status();
        Task<JObject> StatusAsync();

        JObject Sync();
        Task<JObject> SyncAsync();

        JObject AutoConfigure();
        Task<JObject> AutoConfigureAsync();
    }
}
