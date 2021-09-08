using System.Threading.Tasks;
using CoalitionBank.Handlers.Grpc.CommandResults.UsersService;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using ProtoBuf.Grpc.Configuration;

namespace CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService
{
    [Service]
    public interface IUsersGrpcService
    {
        [Operation]
        Task<GetUserCommandResult> GetUser(GetUserCommand command);
        
        [Operation]
        Task<GetUsersCommandResult> GetUsers(GetUsersCommand command);
        
        [Operation]
        Task<GetSpecificUsersCommandResult> GetSpecificUsers(GetSpecificUsersCommand command);

        [Operation]
        Task<CreateUserCommandResult> CreateUser(CreateUserCommand command);

        [Operation]
        Task<DeleteUserCommandResult> DeleteUser(DeleteUserCommand command);
        
        [Operation]
        Task<UpdateUserCommandResult> UpdateUser(UpdateUserCommand command);

    }
}