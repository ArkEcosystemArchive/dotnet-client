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
    public class GenesisTransaction
    {
        public string Id { get; set; }
        public byte Type { get; set; }
        public string Amount { get; set; }
        public string Fee { get; set; }
        public string SenderPublicKey { get; set; }
        public string RecipientId { get; set; }
        public string Signature { get; set; }
        public dynamic Asset { get; set; } // TODO
        public long Timestamp { get; set; }
    }

    [JsonObject]
    public class TransactionTypes
    {
        public byte Transfer { get; set; }
        public byte SecondSignature { get; set; }
        public byte DelegateRegistration { get; set; }
        public byte Vote { get; set; }
        public byte MultiSignature { get; set; }
        public byte Ipfs { get; set; }
        public byte TimelockTransfer { get; set; }
        public byte MultiPayment { get; set; }
        public byte DelegateResignation { get; set; }
    }

    [JsonObject]
    public class TransactionFees
    {
        public long Transfer { get; set; }
        public long SecondSignature { get; set; }
        public long DelegateRegistration { get; set; }
        public long Vote { get; set; }
        public long MultiSignature { get; set; }
        public long Ipfs { get; set; }
        public long TimelockTransfer { get; set; }
        public long MultiPayment { get; set; }
        public long DelegateResignation { get; set; }
    }
}
