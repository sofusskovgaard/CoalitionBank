namespace CoalitionBank.Common.DataTransportObjects.Accounts
{
    public class AccountDto : BaseDto
    {
        public string Title { get; set; }
        
        public string Owner { get; set; }
        
        public string[] UsersWithAccess { get; set; }
        
        public decimal Balance { get; set; }
    }
}