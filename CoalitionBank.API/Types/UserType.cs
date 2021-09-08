using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using GraphQL.Types;

namespace CoalitionBank.API.Types
{
    public class UserType : BaseType<UserDto>
    {
        private readonly IUsersGrpcService _usersGrpcService;
        public UserType(IUsersGrpcService usersGrpcService)
        {
            _usersGrpcService = usersGrpcService;
            
            Field(x => x.Firstname);
            Field(x => x.Lastname);
            Field(x => x.Email);
            FieldAsync<ListGraphType<AccountType>>("accounts", resolve: async context =>
            {
                return await Task.Run(() =>
                {
                    var items = new List<AccountDto>()
                    {
                        new()
                        {
                           Id = "1",
                           Balance = 69,
                           ETag = "1",
                           Owner = "balls",
                           PartitionKey = "balls",
                           Title = "balls account",
                           UsersWithAccess = new []{ "balls" }
                        },
                        new()
                        {
                            Id = "2",
                            Balance = 69,
                            ETag = "1",
                            Owner = "balls",
                            PartitionKey = "balls",
                            Title = "balls super account",
                            UsersWithAccess = new []{ "balls" }
                        }
                    };
                    return items;
                });
            });
        }
    }
}