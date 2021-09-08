using System.Threading.Tasks;
using CoalitionBank.Handlers.Grpc.CommandResults.AccountsService;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using ProtoBuf.Grpc.Configuration;

namespace CoalitionBank.Infrastructure.GrpcServices.AccountsGrpcService
{
    [Service]
    public interface IAccountsGrpcService
    {
        Task<CreateAccountCommandResult> CreateAccount(CreateAccountCommand command);

        Task<DeleteAccountCommandResult> DeleteAccount(DeleteAccountCommand command);

        Task<GetAccountCommandResult> GetAccount(GetAccountCommand command);

        Task<GetAccountsCommandResult> GetAccounts(GetAccountsCommand command);

        Task<UpdateAccountBalanceCommandResult> UpdateAccountBalance(UpdateAccountBalanceCommand command);

        Task<UpdateAccountCommandResult> UpdateAccount(UpdateAccountCommand command);
    }
}