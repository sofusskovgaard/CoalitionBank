namespace CoalitionBank.Common.DataTransportObjects
{
    public interface IBaseDto
    {
        string Id { get; set; }
        
        string PartitionKey { get; set; }
        
        string ETag { get; set; }
    }
}