using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class Bridgechain
    {
        public int BridgechainId { get; set; }
        public int BusinessId { get; set; }
        public List<string> SeedNodes { get; set; }
        public string Name { get; set; }
        public string GenesisHash { get; set; }
        public string BridgechainRepository { get; set; }
    }
}
