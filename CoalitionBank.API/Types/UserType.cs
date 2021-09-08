using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Infrastructure.GrpcServices.AccountsGrpcService;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using GraphQL.Types;

namespace CoalitionBank.API.Types
{
    public class UserType : BaseType<UserDto>
    {
        private readonly IAccountsGrpcService _accountsService;
        
        public UserType(IAccountsGrpcService accountsService)
        {
            _accountsService = accountsService;
            
            Field(x => x.Firstname);
            Field(x => x.Lastname);
            Field(x => x.Email);
            FieldAsync<ListGraphType<AccountType>>("accounts", resolve: async context =>
            {
                var accounts = await _accountsService.GetAccounts(new GetAccountsCommand()
                    { Page = 1, PageSize = 100, PartitionKey = context.Source.Id });
                return accounts.Entities;
            });
        }
    }
}