using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Common.DataTransportObjects.Transactions;
using CoalitionBank.Common.Entities.Transactions;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.CommandResults.TransactionsService;
using CoalitionBank.Handlers.Grpc.Commands.TransactionsService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.TransactionsService
{
    public class GetTransactionCommandHandler : GrpcCommandHandler<GetTransactionCommand, GetTransactionCommandResult>
    {
        private readonly IDataContext _dataContext;
        
        private readonly IMapper _mapper;

        public GetTransactionCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<GetTransactionCommandResult> Invoke(GetTransactionCommand command)
        {
            var entity = await _dataContext.Get<TransactionEntity>(command.Id, command.PartitionKey);
            var dto = _mapper.Map<TransactionDto>(entity);
            return new GetTransactionCommandResult() { Entity = dto };
        }
    }
}