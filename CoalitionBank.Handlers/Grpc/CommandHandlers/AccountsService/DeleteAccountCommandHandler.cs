using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Common.Entities.Accounts;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.CommandResults.AccountsService;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.AccountsService
{
    public class DeleteAccountCommandHandler : GrpcCommandHandler<DeleteAccountCommand, DeleteAccountCommandResult>
    {
        private readonly IDataContext _dataContext;
        
        private readonly IMapper _mapper;

        public DeleteAccountCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<DeleteAccountCommandResult> Invoke(DeleteAccountCommand command)
        {
            var result = await _dataContext.Delete<AccountEntity>(command.Id, command.PartitionKey);
            return new DeleteAccountCommandResult() { Success = result };
        }
    }
}