using System;
using CoalitionBank.API.Helpers;
using CoalitionBank.API.QueryArguments;
using CoalitionBank.API.Types;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using GraphQL.Types;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Client;

namespace CoalitionBank.API.Queries
{
    public class UserQuery : ObjectGraphType<object>, IGraphQueryMarker
    {
        private readonly IUsersGrpcService _usersService;
        
        public UserQuery(IServiceProvider provider)
        {
            _usersService = provider.GetService<IUsersGrpcService>();
            
            FieldAsync<UserType>("user",
                arguments: new SpecificQueryArguments(),
                resolve: async context =>
                {
                    var command = new GetUserCommand
                    {
                        Id = (string)context.Arguments["id"].Value,
                        PartitionKey = (string)context.Arguments["partitionKey"].Value
                    };
                    var result = await _usersService.GetUser(command);
                    return result.User;
                });

            FieldAsync<ListGraphType<UserType>>("users", arguments: new PaginatedQueryArguments(),
                resolve: async context =>
                {
                    var command = new GetUsersCommand
                    {
                        Page = (int)context.Arguments["page"].Value,
                        PageSize = (int)context.Arguments["pageSize"].Value
                    };
                    var result = await _usersService.GetUsers(command);
                    return result.Users;
                });
        }
    }
}