using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class Meta
    {
        public int Count { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public string Self { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
}
