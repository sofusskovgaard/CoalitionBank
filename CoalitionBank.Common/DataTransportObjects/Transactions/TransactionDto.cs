using ProtoBuf;

namespace CoalitionBank.Common.DataTransportObjects.Transactions
{
    [ProtoContract]
    public class TransactionDto : BaseDto
    {
        [ProtoMember(1)]
        public override string Id { get; set; }
        
        [ProtoMember(2)]
        public override string PartitionKey { get; set; }
        
        [ProtoMember(3)]
        public override string ETag { get; set; }
        
        [ProtoMember(4)]
        public string SenderAccount { get; set; }
        
        [ProtoMember(5)]
        public string ReceiverAccount { get; set; }
        
        [ProtoMember(6)]
        public decimal Amount { get; set; }
    }
}