using System;
using System.Linq;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Common.DataTransportObjects.Transactions;
using CoalitionBank.Common.Entities.Transactions;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Infrastructure.GrpcServices.AccountsGrpcService;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.API.Types
{
    public class TransactionType : BaseType<TransactionDto>
    {
        private readonly IAccountsGrpcService _accountsService;
        
        public TransactionType(IAccountsGrpcService accountsService)
        {
            _accountsService = accountsService;

            Field(x => x.Amount);

            FieldAsync<AccountType>("SenderAccount", resolve: async context =>
            {
                if (context.SubFields.Any(pair => pair.Key != "id"))
                {
                    var command = new GetAccountCommand()
                        { Id = context.Source.SenderAccount };
                    var result = await _accountsService.GetAccount(command);
                    return result.Entity;
                }
                else
                {
                    return new AccountDto() { Id = context.Source.SenderAccount };
                }
            });
            
            FieldAsync<AccountType>("ReceiverAccount", resolve: async context =>
            {
                if (context.SubFields.Any(pair => pair.Key != "id"))
                {
                    var command = new GetAccountCommand()
                        { Id = context.Source.ReceiverAccount };
                    var result = await _accountsService.GetAccount(command);
                    return result.Entity;
                }
                else
                {
                    return new AccountDto() { Id = context.Source.ReceiverAccount };
                }
            });
        }
    }
}