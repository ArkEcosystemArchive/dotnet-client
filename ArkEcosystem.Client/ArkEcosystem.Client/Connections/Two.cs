using System;
using System.Net.Http;

namespace ArkEcosystem.Client.Connections
{
    public class Two : IConnection
    {
        HttpClient client;

        public API.Two.IBlocks Blocks { get; private set; }
        public API.Two.IDelegates Delegates { get; private set; }
        public API.Two.INode Node { get; private set; }
        public API.Two.IPeers Peers { get; private set; }
        public API.Two.ITransactions Transactions { get; private set; }
        public API.Two.IVotes Votes { get; private set; }
        public API.Two.IWallets Wallets { get; private set; }

        public Two(string host)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(host)
            };

            client.DefaultRequestHeaders.TryAddWithoutValidation("API-Version", "2");

            InitResources();
        }

        public void SetClient(HttpClient httpClient)
        {
            client = httpClient;

            InitResources();
        }

        void InitResources()
        {
            Blocks = new API.Two.Blocks(client);
            Delegates = new API.Two.Delegates(client);
            Node = new API.Two.Node(client);
            Peers = new API.Two.Peers(client);
            Transactions = new API.Two.Transactions(client);
            Votes = new API.Two.Votes(client);
            Wallets = new API.Two.Wallets(client);
        }
    }
}
