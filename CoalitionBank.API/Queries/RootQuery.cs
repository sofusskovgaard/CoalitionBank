using System;
using CoalitionBank.API.Helpers;
using GraphQL.Types;

namespace CoalitionBank.API.Queries
{
    public class RootQuery : ObjectGraphType<object>
    {
        public RootQuery()
        {
            Name = "RootQuery";
            
            foreach (var type in QueryDiscovery.Discover())
            {
                var query = (ObjectGraphType<object>)Activator.CreateInstance(type);
                foreach (var field in query?.Fields)
                {
                    AddField(field);
                }
            }
        }
    }
}