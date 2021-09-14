using System;
using CoalitionBank.API.Helpers;
using CoalitionBank.API.QueryArguments.CommandQueryArguments;
using CoalitionBank.API.Types;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Infrastructure.GrpcServices.AccountsGrpcService;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.API.Mutations
{
    public class AccountMutations : ObjectGraphType<object>, IGraphMutationMarker
    {
        private readonly IAccountsGrpcService _accountsService;
        
        public AccountMutations(IServiceProvider provider)
        {
            _accountsService = provider.GetService<IAccountsGrpcService>();
            
            FieldAsync<AccountType>("createAccount",
                arguments: new CreateAccountCommandArguments(),
                resolve: async context =>
                {
                    var command = new CreateAccountCommand()
                    { 
                        Entity = new AccountDto()
                        {
                            Owner = context.GetArgument<string>("ownerId"),
                            Title = context.GetArgument<string>("title"),
                            UsersWithAccess = new [] { context.GetArgument<string>("ownerId") }
                        }
                    };
                    
                    var result = await _accountsService.CreateAccount(command);
                    return result.Entity;
                });
            
            FieldAsync<AccountType>("updateAccountBalance",
                arguments: new UpdateAccountBalanceCommandArguments(),
                resolve: async context =>
                {
                    var command = new UpdateAccountBalanceCommand()
                    { 
                        Id = context.GetArgument<string>("id"),
                        PartitionKey = context.GetArgument<string>("partitionKey")
                    };
                    
                    var result = await _accountsService.UpdateAccountBalance(command);
                    return result.Entity;
                });
        }
    }
}