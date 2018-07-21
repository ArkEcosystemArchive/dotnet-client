using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Two.Models
{
    [JsonObject]
    public class Timestamp
    {
        public int Epich { get; set; }
        public int Unix { get; set; }
        public string Human { get; set; }
    }
}
