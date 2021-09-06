namespace CoalitionBank.Common.Entities
{
    public interface IBaseEntity
    {
        string RowKey { get; set; }
        
        string PartitionKey { get; set; }
    }
}