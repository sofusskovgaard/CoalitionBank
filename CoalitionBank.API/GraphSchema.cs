using System;
using CoalitionBank.API.Helpers;
using CoalitionBank.API.Queries;
using GraphQL.Types;
using BindingFlags = System.Reflection.BindingFlags;

namespace CoalitionBank.API
{
    public class GraphSchema : Schema
    {
        public GraphSchema()
        {
            Query = new RootQuery();
        }
    }
}