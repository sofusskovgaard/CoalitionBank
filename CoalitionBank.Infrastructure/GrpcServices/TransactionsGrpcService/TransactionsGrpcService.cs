using System.Threading.Tasks;
using CoalitionBank.Handlers.Grpc.CommandHandlers.TransactionsService;
using CoalitionBank.Handlers.Grpc.CommandHandlers.UsersService;
using CoalitionBank.Handlers.Grpc.CommandResults.TransactionsService;
using CoalitionBank.Handlers.Grpc.Commands.TransactionsService;
using CoalitionBank.Handlers.Helpers.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.Infrastructure.GrpcServices.TransactionsGrpcService
{
    public class TransactionsGrpcService : ITransactionsGrpcService
    {
        private readonly IServiceScope _scope;

        public TransactionsGrpcService(IServiceScopeFactory serviceScopeFactory)
        {
            _scope = serviceScopeFactory.CreateScope();
        }

        public async Task<GetTransactionCommandResult> GetTransaction(GetTransactionCommand command)
        {
            var handler = _scope.Resolve<GetTransactionCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<GetTransactionsCommandResult> GetTransactions(GetTransactionsCommand command)
        {
            var handler = _scope.Resolve<GetTransactionsCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<CreateTransactionCommandResult> CreateTransaction(CreateTransactionCommand command)
        {
            var handler = _scope.Resolve<CreateTransactionCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<UpdateTransactionCommandResult> UpdateTransaction(UpdateTransactionCommand command)
        {
            var handler = _scope.Resolve<UpdateTransactionCommandHandler>();
            return await handler.Invoke(command);
        }
    }
}