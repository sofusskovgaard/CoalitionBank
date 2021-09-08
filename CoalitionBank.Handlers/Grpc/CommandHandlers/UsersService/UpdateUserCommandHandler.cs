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
    public class UpdateUserCommandHandler : GrpcCommandHandler<UpdateUserCommand, UpdateUserCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<UpdateUserCommandResult> Invoke(UpdateUserCommand command)
        {
            var _entity = _mapper.Map<UserEntity>(command.Entity);
            var entity = await _dataContext.Update(_entity);
            var dto = _mapper.Map<UserDto>(entity);
            return new UpdateUserCommandResult() { Entity = dto };
        }
    }
}