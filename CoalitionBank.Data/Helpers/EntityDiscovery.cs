using System;
using System.Linq;
using System.Reflection;
using CoalitionBank.Common.Entities;

namespace CoalitionBank.Data.Helpers
{
    public static class EntityDiscovery
    {
        public static Type[] Discover()
        {
            return Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
                .Where(x => !x.IsAbstract && x.BaseType == typeof(BaseEntity)).ToArray();
        }
    }
}