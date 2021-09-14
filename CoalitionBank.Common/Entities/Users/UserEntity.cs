using System;
using CoalitionBank.Common.Attributes;
using CoalitionBank.Common.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProtoBuf;

namespace CoalitionBank.Common.Entities.Users
{
    [CosmosContainer("Users")]
    public class UserEntity : BaseEntity, IUserEntity
    {
        public UserEntity()
        {
            Id = UUIDGenerator.Generate();
            PartitionKey = "global";
            CreatedAt = DateTime.Now;
        }
        
        public UserEntity(string RowKey = null)
        {
            RowKey = !string.IsNullOrEmpty(RowKey) ? RowKey : UUIDGenerator.Generate();
            PartitionKey = "global";
            CreatedAt = DateTime.Now;
        }

        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        [CosmosUniqueKey]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}