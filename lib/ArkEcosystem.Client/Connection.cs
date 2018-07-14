using System;
using System.Net.Http;
using ArkEcosystem.Client.API;
using ArkEcosystem.Client.API.Two;

namespace ArkEcosystem.Client
{
    public sealed class Connection<T> where T : Api
    {
        public HttpClient Client { get;}

        public T Api { get; }

        public Connection(string host)
        {
            Client = CreateClient(host);
            Api = CreateApi();
        }

        public Connection(HttpClient client)
        {
            Client = client;
            Api = CreateApi();
        }

        private HttpClient CreateClient(string host)
        {
            var client = new HttpClient
            {
                BaseAddress = new System.Uri(host)
            };

            client.DefaultRequestHeaders.TryAddWithoutValidation("API-Version", "1");
            return client;
        }

        private T CreateApi()
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { Client } );
        }

    }
}


