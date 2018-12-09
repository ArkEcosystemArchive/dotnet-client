using System;
using System.Collections.Generic;
using ArkEcosystem.Client.API.Models;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API
{
    [JsonObject]
    public class Response<T>
    {
        public Meta Meta { get; set; }
        public T Data { get; set; }
    }
}
