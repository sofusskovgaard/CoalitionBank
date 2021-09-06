namespace CoalitionBank.Common.Entities.Accounts
{
    public interface IAccountEntity : IBaseEntity
    {
        string Title { get; set; }
        
        string Owner { get; set; }
        
        string[] UsersWithAccess { get; set; }
        
        decimal Balance { get; set; }
    }
}