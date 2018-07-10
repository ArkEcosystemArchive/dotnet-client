using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public interface ITransactions
    {
        JObject All(Dictionary<string, string> parameters = null);
        Task<JObject> AllAsync(Dictionary<string, string> parameters = null);

        JObject Show(string id);
        Task<JObject> ShowAsync(string id);

        JObject AllUnconfirmed(Dictionary<string, string> parameters = null);
        Task<JObject> AllUnconfirmedAsync(Dictionary<string, string> parameters = null);

        JObject ShowUnconfirmed(string id);
        Task<JObject> ShowUnconfirmedAsync(string id);
    }
}
