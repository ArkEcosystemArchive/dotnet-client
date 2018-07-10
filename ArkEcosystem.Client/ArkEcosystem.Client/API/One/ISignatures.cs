using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public interface ISignatures
    {
        JObject Fee();
        Task<JObject> FeeAsync();
    }
}
