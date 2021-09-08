using System;
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

            foreach (var type in QueryDiscovery.Discover())
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