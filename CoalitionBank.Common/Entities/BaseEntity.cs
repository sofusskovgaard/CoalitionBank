namespace CoalitionBank.Common.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public string RowKey { get; set; }
        
        public string PartitionKey { get; set; }
    }
}