using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArkEcosystem.Client.API.Models
{
    [JsonObject]
    public class NodeConfiguration
    {
        public string Nethash { get; set; }
        public int Slip44 { get; set; }
        public int Wif { get; set; }
        public string Token { get; set; }
        public string Symbol { get; set; }
        public string Explorer { get; set; }
        public int Version { get; set; }
        public Dictionary<string, Int16> Ports { get; set; }
        public NodeConstants Constants { get; set; }
        public NodeTransactionPool TransactionPool { get; set; }
    }

    [JsonObject]
    public class NodeCrypto
    {
        public NodeExceptions Exceptions { get; set; }
        public NodeGenesisBlock GenesisBlock { get; set; }
        public List<NodeMilestone> Milestones { get; set; }
        public NodeNetwork Network { get; set; }
    }

    [JsonObject]
    public class NodeExceptions
    {
        public List<string> Blocks { get; set; }
        public List<string> Transactions { get; set; }
        public Dictionary<string, string> OutlookTable { get; set; }
        public Dictionary<string, string> TransactionIdFixTable { get; set; }
        public Dictionary<string, List<string>> WrongTransactionOrder { get; set; }
    }

    [JsonObject]
    public class NodeGenesisBlock
    {
        public byte Version { get; set; }
        public string TotalAmount { get; set; }
        public string TotalFee { get; set; }
        public string Reward { get; set; }
        public string PayloadHash { get; set; }
        public long Timestamp { get; set; }
        public long NumberOfTransactions { get; set; }
        public int PayloadLength { get; set; }
        public string PreviousBlock { get; set; }
        public string GeneratorPublicKey { get; set; }
        public List<GenesisTransaction> Transactions { get; set; }
        public long Height { get; set; }
        public string Id { get; set; }
        public string BlockSignature { get; set; }
    }

    [JsonObject]
    public class NodeMilestone
    {
        public long Height { get; set; }
        public long Reward { get; set; }
        public int ActiveDelegates { get; set; }
        public int BlockTime { get; set; }
        public NodeBlock Block { get; set; }
        public string Epoch { get; set; }
        public NodeFees Fees { get; set; }
        public bool IgnoreInvalidSecondSignatureField { get; set; }
        public bool IgnoreExpiredTransactions { get; set; }
        public long VendorFieldLength { get; set; }
    }

    [JsonObject]
    public class NodeNetwork
    {
        public string Name { get; set; }
        public string MessagePrefix { get; set; }
        public Dictionary<string, long> Bip32 { get; set; }
        public int PubKeyHash { get; set; }
        public string NetHash { get; set; }
        public int Wif { get; set; }
        public int Slip44 { get; set; }
        public int Aip20 { get; set; }
        public Dictionary<string, string> Client { get; set; }
    }

    [JsonObject]
    public class NodeStatus
    {
        public bool Synced { get; set; }
        public long Now { get; set; }
        public long BlocksCount { get; set; }
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
        public NodeFees Fees { get; set; }
        public bool IgnoreInvalidSecondSignatureField { get; set; }
        public bool IgnoreExpiredTransactions { get; set; }
        public long VendorFieldLength { get; set; }
    }

    [JsonObject]
    public class NodeTransactionPool
    {
        public DynamicFees DynamicFees { get; set; }
    }

    [JsonObject]
    public class NodeBlock
    {
        public int Version { get; set; }
        public long MaxTransactions { get; set; }
        public long MaxPayload { get; set; }
        public bool AcceptExpiredTransactionTimestamps { get; set; }
        public bool IdFullSha256 { get; set; }
    }

    [JsonObject]
    public class NodeFees
    {
        public Fees StaticFees { get; set; }
    }

    [JsonObject]
    public class DynamicOffsets
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
    public class FeeStatistics
    {
        public byte Type { get; set; }
        public string Avg { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Sum { get; set; }
    }
}
