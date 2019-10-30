using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class Business
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Vat { get; set; }
        public string Repository { get; set; }
    }
}
