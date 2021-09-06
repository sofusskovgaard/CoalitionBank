using ProtoBuf;

namespace CoalitionBank.Common.DataTransportObjects
{
    public abstract class BaseDto : IBaseDto
    {
        public string RowKey { get; set; }
        public string PartitionKey { get; set; }
    }
}