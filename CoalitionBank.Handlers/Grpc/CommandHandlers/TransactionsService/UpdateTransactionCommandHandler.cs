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
    public class UpdateTransactionCommandHandler : GrpcCommandHandler<UpdateTransactionCommand, UpdateTransactionCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public UpdateTransactionCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<UpdateTransactionCommandResult> Invoke(UpdateTransactionCommand command)
        {
            var _entity = _mapper.Map<TransactionEntity>(command.Entity);
            var entity = await _dataContext.Update(_entity);
            var dto = _mapper.Map<TransactionDto>(entity);
            return new UpdateTransactionCommandResult() { Entity = dto };
        }
    }
}