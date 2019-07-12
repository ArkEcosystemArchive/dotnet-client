using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class Peer
    {
        public string Ip { get; set; }
        public Int16 Port { get; set; }
        public Dictionary<string, Int16> Ports { get; set; }
        public string Version { get; set; }
        public long Height { get; set; }
        public int Latency { get; set; }
    }
}
