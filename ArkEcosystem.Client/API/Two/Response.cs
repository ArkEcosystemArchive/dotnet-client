using System;
using System.Collections.Generic;
using ArkEcosystem.Client.API.Two.Models;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Two
{
    [JsonObject]
    public class Response<T>
    {
        public Meta Meta { get; set; }
        public T Data { get; set; }
    }
}
