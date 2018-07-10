using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public interface INode
    {
        JObject Status();
        Task<JObject> StatusAsync();

        JObject Syncing();
        Task<JObject> SyncingAsync();

        JObject Configuration();
        Task<JObject> ConfigurationAsync();
    }
}
