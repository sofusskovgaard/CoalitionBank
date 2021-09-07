using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Common.Helpers;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.CommandResults.UsersService;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.UsersService
{
    public class CreateUserCommandHandler : GrpcCommandHandler<CreateUserCommand, CreateUserCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<CreateUserCommandResult> Invoke(CreateUserCommand command)
        {
            var _entity = _mapper.Map<UserEntity>(command.Entity);

            if (string.IsNullOrEmpty(_entity.Id))
                _entity.Id = UUIDGenerator.Generate();

            if (string.IsNullOrEmpty(_entity.PartitionKey))
                _entity.PartitionKey = "global";
            
            var entity = await _dataContext.Create(_entity);
            return new CreateUserCommandResult() { Entity = _mapper.Map<SensitiveUserDto>(entity) };
        }
    }
}