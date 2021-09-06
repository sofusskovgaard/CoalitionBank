using CoalitionBank.Common.Attributes;

namespace CoalitionBank.Common.Entities.Accounts
{
    [CosmosContainer("Accounts")]
    public class AccountEntity : BaseEntity, IAccountEntity
    {
        public string Title { get; set; }
        
        public string Owner { get; set; }
        
        public string[] UsersWithAccess { get; set; }
        
        public decimal Balance { get; set; }
    }
}