using System;
using System.Net.NetworkInformation;
using CoalitionBank.API.Helpers;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.API.Queries
{
    public class RootQuery : ObjectGraphType<object>
    {
        public RootQuery(IServiceProvider provider)
        {
            Name = "RootQuery";

            FieldAsync<StringGraphType>("ping_users", resolve: async context =>
            {
                using var pinger = new Ping();
                var reply = await pinger.SendPingAsync(Environment.GetEnvironmentVariable("USERS_SERVICE_URI"));
                return reply.Status == IPStatus.Success ? "Pong" : $"No answer from {Environment.GetEnvironmentVariable("USERS_SERVICE_URI")}";
            });
            
            FieldAsync<StringGraphType>("ping_accounts", resolve: async context =>
            {
                using var pinger = new Ping();
                var reply = await pinger.SendPingAsync(Environment.GetEnvironmentVariable("ACCOUNTS_SERVICE_URI"));
                return reply.Status == IPStatus.Success ? "Pong" : $"No answer from {Environment.GetEnvironmentVariable("ACCOUNTS_SERVICE_URI")}";
            });
            
            FieldAsync<StringGraphType>("ping_transactions", resolve: async context =>
            {
                using var pinger = new Ping();
                var reply = await pinger.SendPingAsync(Environment.GetEnvironmentVariable("TRANSACTIONS_SERVICE_URI"));
                return reply.Status == IPStatus.Success ? "Pong" : $"No answer from {Environment.GetEnvironmentVariable("TRANSACTIONS_SERVICE_URI")}";
            });

            foreach (var type in GraphDiscovery.DiscoverQueries())
            {
                var ctor = type.GetConstructors()[0];
                var query = (ObjectGraphType<object>)ctor.Invoke(new object[] { provider });

                foreach (var field in query?.Fields)
                {
                    AddField(field);
                }
            }
        }
    }
}