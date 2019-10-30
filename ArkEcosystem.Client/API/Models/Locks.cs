using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class Lock
    {
        public string LockId { get; set; }
        public long Amount { get; set; }
        public string SecretHash { get; set; }
        public string SenderPublicKey { get; set; }
        public string RecipientId { get; set; }
        public Timestamp Timestamp { get; set; }
        public byte ExpirationType { get; set; }
        public long ExpirationValue { get; set; }
        public string VendorField { get; set; }
    }
}
