using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class Block
    {
        public string Id { get; set; }
        public byte Version { get; set; }
        public long Height { get; set; }
        public string Previous { get; set; }
        public Forged Forged { get; set; }
        public Payload Payload { get; set; }
        public Generator Generator { get; set; }
        public string Signature { get; set; }
        public int Transactions { get; set; }
        public Timestamp Timestamp { get; set; }
    }

    [JsonObject]
    public class Forged
    {
        public long Reward { get; set; }
        public long Fee { get; set; }
        public long Total { get; set; }
    }

    [JsonObject]
    public class Payload
    {
        public string Hash { get; set; }
        public int Length { get; set; }
    }

    [JsonObject]
    public class Generator
    {
        public string Username { get; set; }
        public string Address { get; set; }
        public string PublicKey { get; set; }
    }
}
