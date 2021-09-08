using System;

namespace CoalitionBank.Common.DataTransportObjects
{
    public abstract class BaseDto : IBaseDto
    {
        public abstract string Id { get; set; }
        public abstract string PartitionKey { get; set; }
        public abstract string ETag { get; set; }
        public abstract DateTime CreatedAt { get; set; }
    }
}