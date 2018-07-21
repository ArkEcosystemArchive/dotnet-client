using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Two.Models
{
    [JsonObject]
    public class Wallet
    {
        public string Address { get; set; }
        public string PublicKey { get; set; }
        public string Balance { get; set; }
        public bool IsDelegate { get; set; }
    }
}
