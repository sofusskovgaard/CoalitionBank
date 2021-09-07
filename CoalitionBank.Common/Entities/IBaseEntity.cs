namespace CoalitionBank.Common.Entities
{
    public interface IBaseEntity
    {
        string Id { get; set; }
        
        string PartitionKey { get; set; }
        
        string ETag { get; set; }
    }
}