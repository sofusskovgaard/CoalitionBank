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
    public class UpdateAccountCommandHandler : GrpcCommandHandler<UpdateAccountCommand, UpdateAccountCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<UpdateAccountCommandResult> Invoke(UpdateAccountCommand command)
        {
            var _entity = _mapper.Map<AccountEntity>(command.Entity);
            var entity = await _dataContext.Update(_entity);
            var dto = _mapper.Map<AccountDto>(entity);
            return new UpdateAccountCommandResult() { Entity = dto };
        }
    }
}