using CoalitionBank.Common.Attributes;
using CoalitionBank.Common.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProtoBuf;

namespace CoalitionBank.Common.Entities.Users
{
    [ProtoContract]
    [CosmosContainer("Users")]
    public class UserEntity : BaseEntity, IUserEntity
    {
        public UserEntity()
        {
            Id = UUIDGenerator.Generate();
            PartitionKey = "global";
        }
        
        public UserEntity(string RowKey = null)
        {
            RowKey = !string.IsNullOrEmpty(RowKey) ? RowKey : UUIDGenerator.Generate();
            PartitionKey = "global";
        }

        [ProtoMember(4)]
        public string Firstname { get; set; }
        
        [ProtoMember(5)]
        public string Lastname { get; set; }
        
        [ProtoMember(6)]
        [CosmosUniqueKey]
        public string Email { get; set; }
        
        [ProtoMember(7)]
        public string Password { get; set; }
    }
}