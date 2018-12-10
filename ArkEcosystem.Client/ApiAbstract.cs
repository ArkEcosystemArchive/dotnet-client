using System.Net.Http;

namespace ArkEcosystem.Client
{
    public abstract class ApiAbstract
    {
        HttpClient Client { get; }

        public ApiAbstract(HttpClient client)
        {
            Client = client;
        }

        public abstract string Version();
    }
}
