using System;
using System.Net.Http;
using ArkEcosystem.Client.API;
using ArkEcosystem.Client.API.Two;

namespace ArkEcosystem.Client
{
    public sealed class Connection<T> where T : Api
    {
        public HttpClient Client { get; }

        public T Api { get; }

        public Connection(string host) : this(CreateClient(host)) { }

        public Connection(HttpClient client)
        {
            Api = CreateApi(client);

            Client.DefaultRequestHeaders.TryAddWithoutValidation("API-Version", Api.Version());
            Client = client;
        }

        private static HttpClient CreateClient(string host)
        {
            var client = new HttpClient
            {
                BaseAddress = new System.Uri(host)
            };

            return client;
        }

        private static T CreateApi(HttpClient client)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { client });
        }

    }
}


