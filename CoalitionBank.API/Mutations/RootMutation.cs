using System;
using CoalitionBank.API.Helpers;
using GraphQL.Types;

namespace CoalitionBank.API.Mutations
{
    public class RootMutation : ObjectGraphType<object>
    {
        public RootMutation(IServiceProvider provider)
        {
            Name = "RootMutation";
            
            foreach (var type in GraphDiscovery.DiscoverMutations())
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