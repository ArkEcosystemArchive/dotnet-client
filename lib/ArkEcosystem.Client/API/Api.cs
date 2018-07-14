using System.Net.Http;

namespace ArkEcosystem.Client.API {
    public abstract class Api
    {
        HttpClient Client { get; }

        public Api(HttpClient client) {
            Client = client;
        }

        public abstract string Version();
    }

}
