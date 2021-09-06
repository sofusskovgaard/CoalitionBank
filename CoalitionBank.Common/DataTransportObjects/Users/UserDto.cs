using ProtoBuf;

namespace CoalitionBank.Common.DataTransportObjects.Users
{
    [ProtoContract]
    public class UserDto : BaseDto
    {
        [ProtoMember(1)]
        public string RowKey { get; set; }

        [ProtoMember(2)]
        public string PartitionKey { get; set; }

        [ProtoMember(3)]
        public string Firstname { get; set; }

        [ProtoMember(4)]
        public string Lastname { get; set; }

        [ProtoMember(5)]
        public string Email { get; set; }
    }
}