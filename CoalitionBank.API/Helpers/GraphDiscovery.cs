using System;
using System.Linq;
using System.Reflection;
using CoalitionBank.API.Mutations;
using CoalitionBank.API.Queries;

namespace CoalitionBank.API.Helpers
{
    public static class GraphDiscovery
    {
        public static Type[] DiscoverQueries()
        {
            return Assembly.GetAssembly(typeof(RootQuery)).GetTypes()
                .Where(x => x.GetInterface(nameof(IGraphQueryMarker)) != null).ToArray();
        }
        
        public static Type[] DiscoverMutations()
        {
            return Assembly.GetAssembly(typeof(RootMutation)).GetTypes()
                .Where(x => x.GetInterface(nameof(IGraphMutationMarker)) != null).ToArray();
        }
    }
}