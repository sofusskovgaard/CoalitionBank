using ProtoBuf;

namespace CoalitionBank.Common.DataTransportObjects.Users
{
    [ProtoContract]
    public class UserDto : BaseDto
    {
        [ProtoMember(1)]
        public override string Id { get; set; }
        
        [ProtoMember(2)]
        public override string PartitionKey { get; set; }
        
        [ProtoMember(3)]
        public override string ETag { get; set; }
        
        [ProtoMember(4)]
        public string Firstname { get; set; }

        [ProtoMember(5)]
        public string Lastname { get; set; }

        [ProtoMember(6)]
        public string Email { get; set; }
    }
}