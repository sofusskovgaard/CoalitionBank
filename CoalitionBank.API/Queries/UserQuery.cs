using System;
using CoalitionBank.API.Helpers;
using CoalitionBank.API.QueryArguments;
using CoalitionBank.API.Types;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using GraphQL.Types;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace CoalitionBank.API.Queries
{
    public class UserQuery : ObjectGraphType<object>, IGraphQueryMarker, IDisposable
    {
        private GrpcChannel _channel;
        
        private readonly IUsersGrpcService _service;
        
        public UserQuery()
        {
            _channel = GrpcChannel.ForAddress("http://users-service");
            _service = _channel.CreateGrpcService<IUsersGrpcService>();

            FieldAsync<UserType>("user",
                arguments: new SpecificQueryArguments(),
                resolve: async context =>
                {
                    var command = new GetUserCommand
                    {
                        Id = (string)context.Arguments["id"].Value,
                        PartitionKey = (string)context.Arguments["partitionKey"].Value
                    };
                    var result = await _service.GetUser(command);
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
                    var result = await _service.GetUsers(command);
                    return result.Users;
                });
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}