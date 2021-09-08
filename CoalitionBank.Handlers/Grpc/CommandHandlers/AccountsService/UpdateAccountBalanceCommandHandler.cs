using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Common.DataTransportObjects.Transactions;
using CoalitionBank.Common.Entities.Accounts;
using CoalitionBank.Common.Entities.Transactions;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.CommandResults.AccountsService;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.AccountsService
{
    public class UpdateAccountBalanceCommandHandler : GrpcCommandHandler<UpdateAccountBalanceCommand, UpdateAccountBalanceCommandResult>
    {
        private readonly IDataContext _dataContext;
        
        private readonly IMapper _mapper;

        public UpdateAccountBalanceCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<UpdateAccountBalanceCommandResult> Invoke(UpdateAccountBalanceCommand command)
        {
            var account = await _dataContext.Get<AccountEntity>(command.Id, command.PartitionKey);
            var entities = await _dataContext.GetFrom<TransactionEntity>(account.LastKnownTransaction, account.Id);

            if (entities != null && entities?.Count() > 0)
            {
                account.Balance += entities.Sum(entity =>
                    entity.SenderAccount == account.Id ? entity.Amount * -1 : entity.Amount);
                account.LastKnownTransaction = entities.Last().Id;
                var entity = await _dataContext.Update(account);
                var dto = _mapper.Map<AccountDto>(entity);
                return new UpdateAccountBalanceCommandResult() { Changed = true, Entity = dto };
            }
            
            return new UpdateAccountBalanceCommandResult() { Changed = false };
        }
    }
}