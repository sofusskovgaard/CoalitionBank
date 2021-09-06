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

        private readonly IMapper _mapper;

        public UsersGrpcService(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        {
            _scope = serviceScopeFactory.CreateScope();
            _mapper = mapper;
        }

        public async Task<GetUserCommandResult> GetUser(GetUserCommand command)
        {
            var handler = _scope.Resolve<GetUserCommandHandler>();
            return await handler.InvokeAsync(command);
        }
    }
}