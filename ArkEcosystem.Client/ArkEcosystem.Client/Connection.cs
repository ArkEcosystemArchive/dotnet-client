using System;
using System.Net.Http;

namespace ArkEcosystem.Client
{
    public class Connection
    {
        HttpClient client;
        readonly int version;

        public Connection(string host, int version)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(host)
            };

            client.DefaultRequestHeaders.TryAddWithoutValidation("API-Version", version.ToString());

            this.version = version;
        }

        public void SetClient(HttpClient httpClient)
        {
            client = httpClient;
        }

        public object Accounts()
        {
            switch (version)
            {
                case 1:
                    return new API.One.Accounts(client);
                default:
                    throw new NotImplementedException();
            }
        }

        public object Blocks()
        {
            switch (version)
            {
                case 1:
                    return new API.One.Blocks(client);
                case 2:
                    return new API.Two.Blocks(client);
                default:
                    throw new NotImplementedException();
            }
        }

        public object Delegates()
        {
            switch (version)
            {
                case 1:
                    return new API.One.Delegates(client);
                case 2:
                    return new API.Two.Delegates(client);
                default:
                    throw new NotImplementedException();
            }
        }

        public object Loader()
        {
            switch (version)
            {
                case 1:
                    return new API.One.Loader(client);
                default:
                    throw new NotImplementedException();
            }
        }

        public object Node()
        {
            switch (version)
            {
                case 2:
                    return new API.Two.Node(client);
                default:
                    throw new NotImplementedException();
            }
        }

        public object Peers()
        {
            switch (version)
            {
                case 1:
                    return new API.One.Peers(client);
                case 2:
                    return new API.Two.Peers(client);
                default:
                    throw new NotImplementedException();
            }
        }

        public object Signatures()
        {
            switch (version)
            {
                case 1:
                    return new API.One.Signatures(client);
                default:
                    throw new NotImplementedException();
            }
        }

        public object Transactions()
        {
            switch (version)
            {
                case 1:
                    return new API.One.Transactions(client);
                case 2:
                    return new API.Two.Transactions(client);
                default:
                    throw new NotImplementedException();
            }
        }

        public object Votes()
        {
            switch (version)
            {
                case 2:
                    return new API.Two.Votes(client);
                default:
                    throw new NotImplementedException();
            }
        }

        public object Wallets()
        {
            switch (version)
            {
                case 2:
                    return new API.Two.Wallets(client);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
