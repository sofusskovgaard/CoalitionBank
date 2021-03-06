using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.CommandResults.UsersService;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.UsersService
{
    public class GetUserCommandHandler : GrpcCommandHandler<GetUserCommand, GetUserCommandResult>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetUserCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<GetUserCommandResult> Invoke(GetUserCommand command)
        {
            var entity = await _dataContext.Get<UserEntity>(command.Id, command.PartitionKey);
            var dto = _mapper.Map<UserDto>(entity);
            return new GetUserCommandResult() { User = dto };
        }
    }
}