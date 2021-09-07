using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using GraphQL.Types;

namespace CoalitionBank.API.Types
{
    public class UserType : BaseType<UserDto>
    {
        public UserType()
        {
            Field(x => x.Firstname);
            Field(x => x.Lastname);
            Field(x => x.Email);
        }
    }
}