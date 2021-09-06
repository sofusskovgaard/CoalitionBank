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
    }
}