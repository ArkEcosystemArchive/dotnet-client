using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class Wallet
    {
        public string Address { get; set; }
        public string PublicKey { get; set; }
        public string Username { get; set; }
        public string SecondPublicKey { get; set; }
        public string Balance { get; set; }
        public bool IsDelegate { get; set; }
    }
}
