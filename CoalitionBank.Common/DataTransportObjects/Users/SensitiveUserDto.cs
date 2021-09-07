using ProtoBuf;

namespace CoalitionBank.Common.DataTransportObjects.Users
{
    [ProtoContract]
    [ProtoInclude(1, typeof(SensitiveUserDto))]
    public class SensitiveUserDto : UserDto
    {
        [ProtoMember(7)]
        public string Password { get; set; }
    }
}