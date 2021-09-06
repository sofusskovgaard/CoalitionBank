namespace CoalitionBank.Common.DataTransportObjects
{
    public interface IBaseDto
    {
        string RowKey { get; set; }
        
        string PartitionKey { get; set; }
    }
}