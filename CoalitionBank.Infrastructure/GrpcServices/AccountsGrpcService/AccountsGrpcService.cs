using System.Threading.Tasks;
using CoalitionBank.Handlers.Grpc.CommandHandlers.AccountsService;
using CoalitionBank.Handlers.Grpc.CommandResults.AccountsService;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Handlers.Helpers.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.Infrastructure.GrpcServices.AccountsGrpcService
{
    public class AccountsGrpcService : IAccountsGrpcService
    {
        private readonly IServiceScope _scope;

        public AccountsGrpcService(IServiceScopeFactory serviceScopeFactory)
        {
            _scope = serviceScopeFactory.CreateScope();
        }

        public async Task<CreateAccountCommandResult> CreateAccount(CreateAccountCommand command)
        {
            var handler = _scope.Resolve<CreateAccountCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<DeleteAccountCommandResult> DeleteAccount(DeleteAccountCommand command)
        {
            var handler = _scope.Resolve<DeleteAccountCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<GetAccountCommandResult> GetAccount(GetAccountCommand command)
        {
            var handler = _scope.Resolve<GetAccountCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<GetAccountsCommandResult> GetAccounts(GetAccountsCommand command)
        {
            var handler = _scope.Resolve<GetAccountsCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<UpdateAccountBalanceCommandResult> UpdateAccountBalance(UpdateAccountBalanceCommand command)
        {
            var handler = _scope.Resolve<UpdateAccountBalanceCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<UpdateAccountCommandResult> UpdateAccount(UpdateAccountCommand command)
        {
            var handler = _scope.Resolve<UpdateAccountCommandHandler>();
            return await handler.Invoke(command);
        }
    }
}