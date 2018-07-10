using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public interface IBlocks
    {
        JObject All(Dictionary<string, string> parameters = null);
        Task<JObject> AllAsync(Dictionary<string, string> parameters = null);

        JObject Show(string id);
        Task<JObject> ShowAsync(string id);

        JObject Transactions(string id, Dictionary<string, string> parameters = null);
        Task<JObject> TransactionsAsync(string id, Dictionary<string, string> parameters = null);

        JObject Search(Dictionary<string, string> parameters);
        Task<JObject> SearchAsync(Dictionary<string, string> parameters);
    }
}
