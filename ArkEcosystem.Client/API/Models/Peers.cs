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
        public string Version { get; set; }
        public long Height { get; set; }
        public string Status { get; set; }
        public string OS { get; set; }
        public int Latency { get; set; }
    }
}
