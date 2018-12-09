using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class Delegate
    {
        public string Username { get; set; }
        public string Address { get; set; }
        public string PublicKey { get; set; }
        public long Votes { get; set; }
        public int Rank { get; set; }
        public Blocks Blocks { get; set; }
        public Production Production { get; set; }
    }

    [JsonObject]
    public class Blocks
    {
        public long Produced { get; set; }
        public long Missed { get; set; }
        public Last Last { get; set; }
    }

    [JsonObject]
    public class Production
    {
        public decimal Approval { get; set; }
        public decimal Productivity { get; set; }

    }

    [JsonObject]
    public class Last
    {
        public string Id { get; set; }
        public Timestamp Timestamp { get; set; }
    }
}
