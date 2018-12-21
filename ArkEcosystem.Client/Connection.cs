using System;
using System.Net.Http;
using ArkEcosystem.Client.API;

namespace ArkEcosystem.Client
{
    public interface IConnection
    {
        ApiAbstract Api { get; }
        HttpClient Client { get; }
    }

    public sealed class Connection : IConnection
    {
        public HttpClient Client { get; }

        public ApiAbstract Api { get; }

        public Connection(string host) : this(CreateClient(host)) { }

        public Connection(HttpClient client)
        {
            Api = CreateApi(client);

            Client = client;
            Client.DefaultRequestHeaders.TryAddWithoutValidation("API-Version", Api.Version());
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        }

        static HttpClient CreateClient(string host)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(host)
            };

            return client;
        }

        static ApiAbstract CreateApi(HttpClient client)
        {
            return (ApiAbstract)Activator.CreateInstance(typeof(ApiAbstract), new object[] { client });
        }
    }
}
