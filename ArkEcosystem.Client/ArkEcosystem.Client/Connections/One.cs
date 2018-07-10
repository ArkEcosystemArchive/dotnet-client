using System;
using System.Net.Http;

namespace ArkEcosystem.Client.Connections
{
    public class One : IConnection
    {
        HttpClient client;

        public API.One.IAccounts Accounts { get; private set; }
        public API.One.IBlocks Blocks { get; private set; }
        public API.One.IDelegates Delegates { get; private set; }
        public API.One.ILoader Loader { get; private set; }
        public API.One.IPeers Peers { get; private set; }
        public API.One.ISignatures Signatures { get; private set; }
        public API.One.ITransactions Transactions { get; private set; }

        public One(string host)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(host)
            };

            client.DefaultRequestHeaders.TryAddWithoutValidation("API-Version", "1");

            InitResources();
        }

        public void SetClient(HttpClient httpClient)
        {
            client = httpClient;

            InitResources();
        }

        void InitResources () {
            Accounts = new API.One.Accounts(client);
            Blocks = new API.One.Blocks(client);
            Delegates = new API.One.Delegates(client);
            Loader = new API.One.Loader(client);
            Peers = new API.One.Peers(client);
            Signatures = new API.One.Signatures(client);
            Transactions = new API.One.Transactions(client);
        }
    }
}
