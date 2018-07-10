using System;
using System.Collections.Generic;

namespace ArkEcosystem.Client
{
    public class ConnectionManager
    {
        string defaultConnection = "main";
        readonly Dictionary<string, Connections.IConnection> connections = new Dictionary<string, Connections.IConnection>();

        public Connections.IConnection Connect(Connections.IConnection connection, string name = "main")
        {

            connections[name] = connection;

            return connections[name];
        }

        public void Disconnect(string name = null)
        {
            connections.Remove(name ?? GetDefaultConnection());
        }

        public Connections.IConnection Connection(string name = null)
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

        public Dictionary<string, Connections.IConnection> GetConnections()
        {
            return connections;
        }
    }
}
