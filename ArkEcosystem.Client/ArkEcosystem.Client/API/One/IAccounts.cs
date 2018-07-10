using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArkEcosystem.Client.Helpers;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public interface IAccounts
    {
        JObject All(Dictionary<string, string> parameters = null);
        Task<JObject> AllAsync(Dictionary<string, string> parameters = null);

        JObject Show(string address);
        Task<JObject> ShowAsync(string address);

        JObject Count();
        Task<JObject> CountAsync();

        JObject Delegates(string address);
        Task<JObject> DelegatesAsync(string address);

        JObject Fee();
        Task<JObject> FeeAsync();

        JObject Balance(string address);
        Task<JObject> BalanceAsync(string address);

        JObject PublicKey(string address);
        Task<JObject> PublicKeyAsync(string address);

        JObject Top(Dictionary<string, string> parameters = null);
        Task<JObject> TopAsync(Dictionary<string, string> parameters = null);
    }
}
