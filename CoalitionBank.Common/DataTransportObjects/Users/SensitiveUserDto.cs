using ProtoBuf;

namespace CoalitionBank.Common.DataTransportObjects.Users
{
    [ProtoContract]
    public class SensitiveUserDto : UserDto
    {
        [ProtoMember(6)]
        public string Password { get; set; }
    }
}