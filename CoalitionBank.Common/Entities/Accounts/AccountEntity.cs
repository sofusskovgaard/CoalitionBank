using CoalitionBank.Common.Attributes;
using CoalitionBank.Common.Helpers;

namespace CoalitionBank.Common.Entities.Accounts
{
    [CosmosContainer("Accounts")]
    public class AccountEntity : BaseEntity, IAccountEntity
    {
        public AccountEntity(string RowKey = null, string PartitionKey = null)
        {
            RowKey = !string.IsNullOrEmpty(RowKey) ? RowKey : UUIDGenerator.Generate();
            PartitionKey = PartitionKey;
        }

        public string Title { get; set; }
        
        public string Owner { get; set; }
        
        public string[] UsersWithAccess { get; set; }
        
        public decimal Balance { get; set; }
        
        public string LastKnownTransaction { get; set; }
    }
}