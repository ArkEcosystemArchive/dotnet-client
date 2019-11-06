using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class NodeConfiguration
    {
        public string Nethash { get; set; }
        public string Token { get; set; }
        public string Symbol { get; set; }
        public string Explorer { get; set; }
        public int Version { get; set; }
        public Dictionary<string, Int16?> Ports { get; set; }
        public NodeConstants Constants { get; set; }
        public TransactionPoolConfiguration TransactionPool { get; set; }

        public class TransactionPoolConfiguration
        {
            public DynamicFees DynamicFees { get; set; }
        }
    }

    [JsonObject]
    public class NodeStatus
    {
        public bool Synced { get; set; }
        public long Now { get; set; }
        public long BlocksCount { get; set; }
        public int Timestamp { get; set; }
    }

    [JsonObject]
    public class NodeSyncing
    {
        public bool Syncing { get; set; }
        public long Blocks { get; set; }
        public long Height { get; set; }
        public string Id { get; set; }
    }

    [JsonObject]
    public class NodeConstants
    {
        public long Height { get; set; }
        public long Reward { get; set; }
        public int ActiveDelegates { get; set; }
        public int BlockTime { get; set; }
        public NodeBlock Block { get; set; }
        public string Epoch { get; set; }
        public Fees Fees { get; set; }
        public DynamicOffsets DynamicOffsets { get; set; }
    }

    [JsonObject]
    public class NodeBlock
    {
        public int Version { get; set; }
        public long MaxTransactions { get; set; }
        public long MaxPayload { get; set; }
    }


    [JsonObject]
    public class DynamicOffsets
    {
        public long Transfer { get; set; }
        public long SecondSignature { get; set; }
        public long DelegateRegistration { get; set; }
        public long Vote { get; set; }
        public long MultiSignature { get; set; }
        public long IPFS { get; set; }
        public long TimelockTransfer { get; set; }
        public long MultiPayment { get; set; }
        public long DelegateResignation { get; set; }
    }

    [JsonObject]
    public class DynamicFees
    {
        public long MinFeePool { get; set; }
        public long MinFeeBroadast { get; set; }
        public Fees AddonBytes { get; set; }
    }

    [JsonObject]
    public class FeeStatistics
    {
        public byte Type { get; set; }
        public long Avg { get; set; }
        public long Min { get; set; }
        public long Max { get; set; }
        public long Sum { get; set; }
    }
}
