using System.Net.Http;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API
{
    public sealed class Two : Api
    {
        public Blocks Blocks { get; }
        public Delegates Delegates { get; }
        public Node Node { get; }
        public Peers Peers { get; }
        public Transactions Transactions { get; }
        public Votes Votes { get; }
        public Wallets Wallets { get; }

        public Two(HttpClient client) : base(client)
        {
            Blocks = new Blocks(client);
            Delegates = new Delegates(client);
            Node = new Node(client);
            Peers = new Peers(client);
            Transactions = new Transactions(client);
            Votes = new Votes(client);
            Wallets = new Wallets(client);
        }

        public override string Version()
        {
            return "2";
        }

        public static Response<T> ConvertResponse<T>(string json)
        {
            return JsonConvert.DeserializeObject<Response<T>>(json);//, new JsonConverter<Response<T>>());
        }
    }

}
