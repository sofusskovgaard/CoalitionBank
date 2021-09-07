using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.CommandResults.UsersService;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.UsersService
{
    public class DeleteUserCommandHandler : GrpcCommandHandler<DeleteUserCommand, DeleteUserCommandResult>
    {
        private readonly IDataContext _dataContext;
        
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<DeleteUserCommandResult> Invoke(DeleteUserCommand command)
        {
            var result = await _dataContext.Delete<UserEntity>(command.Id, command.PartitionKey);
            return new DeleteUserCommandResult() { Success = result };
        }
    }
}