using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class Transaction
    {
        public string Id { get; set; }
        public string BlockId { get; set; }
        public byte Type { get; set; }
        public long Amount { get; set; }
        public long Fee { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Signature { get; set; }
        public string VendorField { get; set; }
        public dynamic Asset { get; set; } // TODO
        public long Confirmations { get; set; }
        public Timestamp Timestamp { get; set; }
    }

    [JsonObject]
    public class TransactionTypes
    {
        [JsonProperty("TRANSFER")]
        public byte Transfer { get; set; }
        [JsonProperty("SECOND_SIGNATURE")]
        public byte SecondSignature { get; set; }
        [JsonProperty("DELEGATE_REGISTRATION")]
        public byte DelegateRegistration { get; set; }
        [JsonProperty("VOTE")]
        public byte Vote { get; set; }
        [JsonProperty("MULTI_SIGNATURE")]
        public byte MultiSignature { get; set; }
        [JsonProperty("IPFS")]
        public byte IPFS { get; set; }
        [JsonProperty("TIMELOCK_TRANSFER")]
        public byte TimelockTransfer { get; set; }
        [JsonProperty("MULTI_PAYMENT")]
        public byte MultiPayment { get; set; }
        [JsonProperty("DELEGATE_RESIGNATION")]
        public byte DelegateResignation { get; set; }
    }
}
