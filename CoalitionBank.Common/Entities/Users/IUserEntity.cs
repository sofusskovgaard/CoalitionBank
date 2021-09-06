namespace CoalitionBank.Common.Entities.Users
{
    public interface IUserEntity : IBaseEntity
    {
        string Firstname { get; set; }

        string Lastname { get; set; }
        
        string Email { get; set; }
        
        string Password { get; set; }
    }
}