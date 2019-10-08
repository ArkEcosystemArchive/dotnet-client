using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class RoundDelegate
    {
        public string PublicKey { get; set; }
        public string Votes { get; set; }
    }
}
