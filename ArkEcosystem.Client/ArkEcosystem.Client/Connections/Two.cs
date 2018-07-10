// Author:
//       Brian Faust <brian@ark.io>
//
// Copyright (c) 2018 Ark Ecosystem <info@ark.io>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
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
