using CoalitionBank.Common.Entities.Users;
using GraphQL.Types;

namespace CoalitionBank.API.Types
{
    public class UserType : BaseType<UserEntity>
    {
        public UserType()
        {
            Field(x => x.Firstname);
            Field(x => x.Lastname);
            Field(x => x.Email);
        }
    }
}