namespace CoalitionBank.Common.Entities.Users
{
    public class UserEntity : BaseEntity, IUserEntity
    {
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}