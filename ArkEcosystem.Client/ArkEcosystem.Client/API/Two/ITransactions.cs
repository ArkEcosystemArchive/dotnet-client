using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.Two
{
    public interface ITransactions
    {
        JObject All(Dictionary<string, string> parameters = null);
        Task<JObject> AllAsync(Dictionary<string, string> parameters = null);

        JObject Create(Dictionary<string, dynamic> parameters);
        Task<JObject> CreateAsync(Dictionary<string, dynamic> parameters);

        JObject Show(string id);
        Task<JObject> ShowAsync(string id);

        JObject AllUnconfirmed(Dictionary<string, string> parameters = null);
        Task<JObject> AllUnconfirmedAsync(Dictionary<string, string> parameters = null);

        JObject ShowUnconfirmed(string id);
        Task<JObject> ShowUnconfirmedAsync(string id);

        JObject Search(Dictionary<string, string> parameters);
        Task<JObject> SearchAsync(Dictionary<string, string> parameters);

        JObject Types();
        Task<JObject> TypesAsync();
    }
}
