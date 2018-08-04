using System;
using System.Net.Http;
using ArkEcosystem.Client.API;

namespace ArkEcosystem.Client
{
    public interface IConnection<out T> where T : Api {
        T Api { get; }
        HttpClient Client { get; }
    }

    public sealed class Connection<T> : IConnection<T> where T: Api
    {
        public HttpClient Client { get; }

        public T Api { get; }

        public Connection(string host) : this(CreateClient(host)) { }

        public Connection(HttpClient client)
        {
            Api = CreateApi(client);

            Client = client;
            Client.DefaultRequestHeaders.TryAddWithoutValidation("API-Version", Api.Version());
        }

        static HttpClient CreateClient(string host)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(host)
            };

            return client;
        }

        static T CreateApi(HttpClient client)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { client });
        }

    }
}


