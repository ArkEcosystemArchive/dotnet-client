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
using System.Collections.Generic;
using ArkEcosystem.Client.API;

namespace ArkEcosystem.Client
{
    public class ConnectionManager<T> where T : Api
    {
        string defaultConnection = "main";

        readonly Dictionary<string, Connection<T>> connections = new Dictionary<string, Connection<T>>();

        public Connection<T> Connect(Connection<T> connection, string name = "main")
        {

            connections[name] = connection;

            return connections[name];
        }

        public void Disconnect(string name = null)
        {
            connections.Remove(name ?? GetDefaultConnection());
        }

        public Connection<T> Connection(string name = null)
        {
            return connections[name ?? GetDefaultConnection()];
        }

        public string GetDefaultConnection()
        {
            return defaultConnection;
        }

        public void SetDefaultConnection(string name)
        {
            defaultConnection = name;
        }

        public Dictionary<string, Connection<T>> GetConnections()
        {
            return connections;
        }
    }
}
