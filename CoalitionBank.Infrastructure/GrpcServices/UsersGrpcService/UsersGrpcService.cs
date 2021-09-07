using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Handlers.Grpc.CommandHandlers.UsersService;
using CoalitionBank.Handlers.Grpc.CommandResults.UsersService;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Handlers.Helpers.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService
{
    public class UsersGrpcService : IUsersGrpcService
    {
        private readonly IServiceScope _scope;

        public UsersGrpcService(IServiceScopeFactory serviceScopeFactory)
        {
            _scope = serviceScopeFactory.CreateScope();
        }

        public async Task<GetUserCommandResult> GetUser(GetUserCommand command)
        {
            var handler = _scope.Resolve<GetUserCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<GetUsersCommandResult> GetUsers(GetUsersCommand command)
        {
            var handler = _scope.Resolve<GetUsersCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<CreateUserCommandResult> CreateUser(CreateUserCommand command)
        {
            var handler = _scope.Resolve<CreateUserCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<DeleteUserCommandResult> DeleteUser(DeleteUserCommand command)
        {
            var handler = _scope.Resolve<DeleteUserCommandHandler>();
            return await handler.Invoke(command);
        }

        public async Task<UpdateUserCommandResult> UpdateUser(UpdateUserCommand command)
        {
            var handler = _scope.Resolve<UpdateUserCommandHandler>();
            return await handler.Invoke(command);
        }
    }
}