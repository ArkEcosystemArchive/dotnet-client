using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class Fees
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

    [JsonObject]
    public class DynamicFees
    {
        public bool Enabled { get; set; }
        public long MinFeePool { get; set; }
        public long MinFeeBroadcast { get; set; }
        public Fees AddonBytes { get; set; }
    }
}
