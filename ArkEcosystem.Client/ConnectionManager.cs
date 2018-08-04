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
using System.Collections.Generic;
using ArkEcosystem.Client.API;

namespace ArkEcosystem.Client
{
    public class ConnectionManager
    {
        string defaultConnection = "main";

        readonly Dictionary<string, IConnection<Api>> connections = new Dictionary<string, IConnection<Api>>();

        public IConnection<T> Connect<T>(IConnection<T> connection, string name = "main") where T : Api
        {
            if (connections.ContainsKey(name)) {
                throw new Exception(string.Format("Connection '{0}' already exists.", name));
            }

            connections[name] = connection as IConnection<Api>;
            return connection;
        }

        public void Disconnect(string name = null)
        {
            connections.Remove(name ?? GetDefaultConnection());
        }

        public IConnection<T> Connection<T>(string name = null) where T : Api
        {
            return connections[name ?? GetDefaultConnection()] as IConnection<T>;
        }

        public string GetDefaultConnection()
        {
            return defaultConnection;
        }

        public void SetDefaultConnection(string name)
        {
            defaultConnection = name;
        }

        public Dictionary<string, IConnection<Api>> GetConnections()
        {
            return connections;
        }
    }
}
