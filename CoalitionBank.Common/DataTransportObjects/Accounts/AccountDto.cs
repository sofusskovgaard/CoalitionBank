using System;
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
        public override DateTime CreatedAt { get; set; }
        
        [ProtoMember(5)]
        public string Title { get; set; }
        
        [ProtoMember(6)]
        public string Owner { get; set; }
        
        [ProtoMember(7)]
        public string[] UsersWithAccess { get; set; }
        
        [ProtoMember(8)]
        public decimal Balance { get; set; }
        
        [ProtoMember(9)]
        public string LastKnownTransaction { get; set; }
    }
}