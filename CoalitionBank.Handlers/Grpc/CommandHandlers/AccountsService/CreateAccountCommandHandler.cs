using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Common.Entities.Accounts;
using CoalitionBank.Common.Helpers;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.CommandResults.AccountsService;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.AccountsService
{
    public class CreateAccountCommandHandler : GrpcCommandHandler<CreateAccountCommand, CreateAccountCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<CreateAccountCommandResult> Invoke(CreateAccountCommand command)
        {
            var _entity = _mapper.Map<AccountEntity>(command.Entity);
            
            if (string.IsNullOrEmpty(_entity.Id))
                _entity.Id = UUIDGenerator.Generate();
            
            if (string.IsNullOrEmpty(_entity.PartitionKey))
                _entity.PartitionKey = _entity.Owner;

            var entity = await _dataContext.Create(_entity);
            var dto = _mapper.Map<AccountDto>(entity);
            return new CreateAccountCommandResult() { Entity = dto };
        }
    }
}