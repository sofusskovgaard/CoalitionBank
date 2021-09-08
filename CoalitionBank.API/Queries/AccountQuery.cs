using System;
using CoalitionBank.API.Helpers;
using CoalitionBank.API.QueryArguments;
using CoalitionBank.API.Types;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Infrastructure.GrpcServices.AccountsGrpcService;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.API.Queries
{
    public class AccountQuery : ObjectGraphType<object>, IGraphQueryMarker
    {
        private readonly IAccountsGrpcService _accountsService;
        
        public AccountQuery(IServiceProvider provider)
        {
            _accountsService = provider.GetService<IAccountsGrpcService>();
            
            FieldAsync<AccountType>("account", arguments: new SpecificQueryArguments(),
                resolve: async context =>
                {
                    var command = new GetAccountCommand()
                    {
                        Id = (string)context.Arguments["id"].Value,
                        PartitionKey = (string)context.Arguments["partitionKey"].Value
                    };
                    var result = await _accountsService.GetAccount(command);
                    return result.Entity;
                });
            
            FieldAsync<ListGraphType<AccountType>>("accounts", arguments: new PaginatedQueryArguments(),
                resolve: async context =>
                {
                    var command = new GetAccountsCommand()
                    {
                        PartitionKey = (string)context.Arguments["partitionKey"].Value,
                        Page = (int)context.Arguments["page"].Value,
                        PageSize = (int)context.Arguments["pageSize"].Value
                    };
                    var result = await _accountsService.GetAccounts(command);
                    return result.Entities;
                });
        }
    }
}