using System;
using System.Linq;
using System.Reflection;
using CoalitionBank.API.Queries;

namespace CoalitionBank.API.Helpers
{
    public static class QueryDiscovery
    {
        public static Type[] Discover()
        {
            return Assembly.GetAssembly(typeof(RootQuery)).GetTypes()
                .Where(x => x.GetInterface(nameof(IGraphQueryMarker)) != null).ToArray();
        }
    }
}