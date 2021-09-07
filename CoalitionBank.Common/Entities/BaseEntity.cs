using System.Text.Json.Serialization;
using CoalitionBank.Common.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProtoBuf;

namespace CoalitionBank.Common.Entities
{
    [ProtoContract]
    public abstract class BaseEntity : IBaseEntity
    {
        [ProtoMember(1)]
        public string Id { get; set; }
        
        [ProtoMember(2)]
        public string PartitionKey { get; set; }
        
        [ProtoMember(3)]
        [JsonPropertyName("_etag")]
        public string ETag { get; set; }
    }
}