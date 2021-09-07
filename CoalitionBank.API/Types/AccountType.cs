using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Common.Entities.Accounts;
using GraphQL.Types;

namespace CoalitionBank.API.Types
{
    public class AccountType : BaseType<AccountDto>
    {
        public AccountType()
        {
            Field(x => x.Title);
            Field(x => x.Balance);
            Field(x => x.Owner, type: typeof(UserType));
            Field(x => x.UsersWithAccess, type: typeof(ListGraphType<UserType>));
        }
    }
}