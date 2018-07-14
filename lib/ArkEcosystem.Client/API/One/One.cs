using System.Net.Http;

namespace ArkEcosystem.Client.API.One
{

    public sealed class One : Api
    {
        public Accounts Accounts { get; }
        public Blocks Blocks { get; }
        public Delegates Delegates { get; }
        public Loader Loader { get; }
        public Peers Peers { get; }
        public Signatures Signatures { get; }
        public Transactions Transactions { get; }

        public One(HttpClient client) : base(client)
        {
            Accounts = new Accounts(client);
            Blocks = new Blocks(client);
            Delegates = new Delegates(client);
            Loader = new Loader(client);
            Peers = new Peers(client);
            Signatures = new Signatures(client);
            Transactions = new Transactions(client);
        }

        public override string Version()
        {
            return "1";
        }
    }

}
