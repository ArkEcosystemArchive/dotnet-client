using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArkEcosystem.Client.API.One
{
    public class Signatures : ISignatures
    {
        readonly HttpClient httpClient;

        public Signatures(HttpClient client)
        {
            httpClient = client;
        }

        public JObject Fee()
        {
            return FeeAsync().Result;
        }

        public async Task<JObject> FeeAsync()
        {
            var response = await httpClient.GetStringAsync("signatures/fee");

            return JObject.Parse(response);
        }
    }
}
