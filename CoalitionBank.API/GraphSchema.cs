using System;
using CoalitionBank.API.Helpers;
using CoalitionBank.API.Queries;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using BindingFlags = System.Reflection.BindingFlags;

namespace CoalitionBank.API
{
    public class GraphSchema : Schema
    {
        public GraphSchema(IServiceProvider provider) : base(provider)
        {
            Query = new RootQuery(this);
        }
    }
}