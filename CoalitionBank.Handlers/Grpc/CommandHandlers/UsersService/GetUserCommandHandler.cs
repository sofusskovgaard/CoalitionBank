using AutoMapper;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Handlers.Grpc.CommandResults.UsersService;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.UsersService
{
    public class GetUserCommandHandler : GrpcCommandHandler<GetUserCommand, GetUserCommandResult>
    {
        private readonly IMapper _mapper;

        public GetUserCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override GetUserCommandResult Invoke(GetUserCommand command)
        {
            return new GetUserCommandResult
            {
                User = _mapper.Map<UserDto>(new UserEntity
                {
                    RowKey = command.RowKey,
                    PartitionKey = command.PartitionKey,
                    Firstname = "Bruh",
                    Lastname = "Ski",
                    Email = "bruh.ski@mail.com"
                })
            };
        }
    }
}