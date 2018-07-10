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
