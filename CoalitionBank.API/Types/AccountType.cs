using System.Linq;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Accounts;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using GraphQL.Types;

namespace CoalitionBank.API.Types
{
    public class AccountType : BaseType<AccountDto>
    {
        private readonly IUsersGrpcService _usersService;
        public AccountType(IUsersGrpcService usersService)
        {
            _usersService = usersService;
            
            Field(x => x.Title);
            Field(x => x.Balance);

            FieldAsync<UserType>("Owner", resolve: async context =>
            {
                if (context.SubFields.Any(pair => pair.Key != "id"))
                {
                    var command = new GetUserCommand()
                        { PartitionKey = "global", Id = context.Source.Owner };
                    var result = await _usersService.GetUser(command);
                    return result.User;
                }
                else
                {
                    return new UserDto() { Id = context.Source.Owner, PartitionKey = "global"};
                }
            });
            
            FieldAsync<ListGraphType<UserType>>("UsersWithAccess", resolve: async context =>
            {
                if (context.SubFields.Any(pair => pair.Key != "id"))
                {
                    var command = new GetSpecificUsersCommand()
                        { Ids = context.Source.UsersWithAccess };
                    var result = await _usersService.GetSpecificUsers(command);
                    return result.Entities;
                }
                else
                {
                    return context.Source.UsersWithAccess.Select(item => new UserDto()
                        { Id = item, PartitionKey = "global" });
                }
            });
        }
    }
}