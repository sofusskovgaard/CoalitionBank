using System;
using System.Text.Json.Serialization;
using CoalitionBank.Common.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProtoBuf;

namespace CoalitionBank.Common.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public string Id { get; set; }
        
        public string PartitionKey { get; set; }
        
        [JsonPropertyName("_etag")]
        public string ETag { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}