using ProtoBuf;

namespace CoalitionBank.Common.DataTransportObjects.Accounts
{
    [ProtoContract]
    public class AccountDto : BaseDto
    {
        [ProtoMember(1)]
        public override string Id { get; set; }
        
        [ProtoMember(2)]
        public override string PartitionKey { get; set; }
        
        [ProtoMember(3)]
        public override string ETag { get; set; }
        
        [ProtoMember(4)]
        public string Title { get; set; }
        
        [ProtoMember(5)]
        public string Owner { get; set; }
        
        [ProtoMember(6)]
        public string[] UsersWithAccess { get; set; }
        
        [ProtoMember(7)]
        public decimal Balance { get; set; }
    }
}