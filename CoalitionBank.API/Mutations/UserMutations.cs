using System;
using CoalitionBank.API.Helpers;
using CoalitionBank.API.QueryArguments;
using CoalitionBank.API.QueryArguments.CommandQueryArguments;
using CoalitionBank.API.Types;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.API.Mutations
{
    public class UserMutations : ObjectGraphType<object>, IGraphMutationMarker
    {
        private readonly IUsersGrpcService _usersService;
        
        public UserMutations(IServiceProvider provider)
        {
            _usersService = provider.GetService<IUsersGrpcService>();       
            
            FieldAsync<UserType>("createUser",
                arguments: new CreateUserCommandArguments(),
                resolve: async context =>
                {
                    var command = new CreateUserCommand()
                    { 
                        Entity = new UserDto()
                        {
                            Firstname = context.GetArgument<string>("firstname"),
                            Lastname = context.GetArgument<string>("lastname"),
                            Email = context.GetArgument<string>("email"),
                            Password = context.GetArgument<string>("password")
                        }
                    };
                    
                    var result = await _usersService.CreateUser(command);
                    return result.Entity;
                });
        }
    }
}