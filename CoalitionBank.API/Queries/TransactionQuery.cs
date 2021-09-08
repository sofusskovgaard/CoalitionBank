using System;
using CoalitionBank.API.Helpers;
using CoalitionBank.API.QueryArguments;
using CoalitionBank.API.Types;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Handlers.Grpc.Commands.TransactionsService;
using CoalitionBank.Infrastructure.GrpcServices.AccountsGrpcService;
using CoalitionBank.Infrastructure.GrpcServices.TransactionsGrpcService;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.API.Queries
{
    public class TransactionQuery : ObjectGraphType<object>, IGraphQueryMarker
    {
        private readonly ITransactionsGrpcService _transactionsService;
        
        public TransactionQuery(IServiceProvider provider)
        {
            _transactionsService = provider.GetService<ITransactionsGrpcService>();
            
            FieldAsync<TransactionType>("transaction", arguments: new SpecificQueryArguments(),
                resolve: async context =>
                {
                    var command = new GetTransactionCommand()
                    {
                        Id = (string)context.Arguments["id"].Value,
                        PartitionKey = (string)context.Arguments["partitionKey"].Value
                    };
                    var result = await _transactionsService.GetTransaction(command);
                    return result.Entity;
                });
            
            FieldAsync<ListGraphType<TransactionType>>("transactions", arguments: new PaginatedQueryArguments(),
                resolve: async context =>
                {
                    var command = new GetTransactionsCommand()
                    {
                        PartitionKey = (string)context.Arguments["partitionKey"].Value,
                        Page = (int)context.Arguments["page"].Value,
                        PageSize = (int)context.Arguments["pageSize"].Value
                    };
                    var result = await _transactionsService.GetTransactions(command);
                    return result.Entities;
                });
        }
    }
}