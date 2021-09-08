using System.Threading.Tasks;
using CoalitionBank.Handlers.Grpc.CommandResults.TransactionsService;
using CoalitionBank.Handlers.Grpc.Commands.TransactionsService;
using ProtoBuf.Grpc.Configuration;

namespace CoalitionBank.Infrastructure.GrpcServices.TransactionsGrpcService
{
    [Service]
    public interface ITransactionsGrpcService
    {
        [Operation]
        public Task<GetTransactionCommandResult> GetTransaction(GetTransactionCommand command);

        [Operation]
        public Task<GetTransactionsCommandResult> GetTransactions(GetTransactionsCommand command);

        [Operation]
        public Task<CreateTransactionCommandResult> CreateTransaction(CreateTransactionCommand command);

        [Operation]
        public Task<UpdateTransactionCommandResult> UpdateTransaction(UpdateTransactionCommand command);
    }
}