using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Common.DataTransportObjects.Transactions;
using CoalitionBank.Common.Entities.Transactions;
using CoalitionBank.Common.Helpers;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.CommandResults.TransactionsService;
using CoalitionBank.Handlers.Grpc.Commands.TransactionsService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.TransactionsService
{
    public class CreateTransactionCommandHandler : GrpcCommandHandler<CreateTransactionCommand, CreateTransactionCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<CreateTransactionCommandResult> Invoke(CreateTransactionCommand command)
        {
            var _senderTransaction = _mapper.Map<TransactionEntity>(command.Entity);
            var _receiverTransaction = _mapper.Map<TransactionEntity>(command.Entity);
            
            if (string.IsNullOrEmpty(_senderTransaction.Id))
                _senderTransaction.Id = UUIDGenerator.Generate();

            _senderTransaction.PartitionKey = _senderTransaction.SenderAccount;
            _receiverTransaction.PartitionKey = _senderTransaction.ReceiverAccount;
            _receiverTransaction.Id = UUIDGenerator.Generate();

            var result = await _dataContext.CreateMany(new[] { _senderTransaction, _receiverTransaction });
            
            return new CreateTransactionCommandResult
            {
                SenderTransaction =
                    _mapper.Map<TransactionDto>(result.FirstOrDefault(x => x.Id == _senderTransaction.Id)),
                ReceiverTransaction = 
                    _mapper.Map<TransactionDto>(result.FirstOrDefault(x => x.Id == _receiverTransaction.Id))
            };
        }
    }
}