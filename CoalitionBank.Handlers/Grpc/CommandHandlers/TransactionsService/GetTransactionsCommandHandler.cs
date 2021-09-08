using System.Collections.Generic;
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
    public class GetTransactionsCommandHandler : GrpcCommandHandler<GetTransactionsCommand, GetTransactionsCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public GetTransactionsCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<GetTransactionsCommandResult> Invoke(GetTransactionsCommand command)
        {
            var entities = await _dataContext.Get<TransactionEntity>(command.PartitionKey, command.Page, command.PageSize);
            var dtos = _mapper.Map<IEnumerable<TransactionDto>>(entities);
            return new GetTransactionsCommandResult() { Entities = dtos };
        }
    }
}