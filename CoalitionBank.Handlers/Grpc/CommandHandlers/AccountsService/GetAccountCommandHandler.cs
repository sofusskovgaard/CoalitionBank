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
    public class GetAccountCommandHandler : GrpcCommandHandler<GetAccountCommand, GetAccountCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;
        
        public GetAccountCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<GetAccountCommandResult> Invoke(GetAccountCommand command)
        {
            var entity = await _dataContext.Get<AccountEntity>(command.Id, command.PartitionKey);
            var dto = _mapper.Map<AccountDto>(entity);
            return new GetAccountCommandResult() { Entity = dto };
        }
    }
}