using System;
using CoalitionBank.API.Helpers;
using CoalitionBank.API.QueryArguments.CommandQueryArguments;
using CoalitionBank.API.Types;
using CoalitionBank.Common.DataTransportObjects.Transactions;
using CoalitionBank.Handlers.Grpc.Commands.TransactionsService;
using CoalitionBank.Infrastructure.GrpcServices.TransactionsGrpcService;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.API.Mutations
{
    public class TransactionMutations : ObjectGraphType<object>, IGraphMutationMarker
    {
        private readonly ITransactionsGrpcService _transactionsService;
        
        public TransactionMutations(IServiceProvider provider)
        {
            _transactionsService = provider.GetService<ITransactionsGrpcService>();
            
            FieldAsync<TransactionType>("createTransaction",
                arguments: new CreateTransactionCommandArguments(),
                resolve: async context =>
                {
                    var command = new CreateTransactionCommand()
                    { 
                        Entity = new TransactionDto()
                        {
                            SenderAccount = context.GetArgument<string>("senderAccountId"),
                            ReceiverAccount = context.GetArgument<string>("receiverAccountId"),
                            Amount = context.GetArgument<decimal>("amount")
                        }
                    };
                    
                    var result = await _transactionsService.CreateTransaction(command);
                    return result.SenderTransaction;
                });
        }
    }
}