using System;
using System.Linq;
using System.Reflection;

namespace CoalitionBank.Handlers.Helpers.Discovery
{
    public static class CommandHandlerDiscovery
    {
        public static Type[] Discover(Type commandHandlerMarker)
        {
            return Assembly.GetAssembly(commandHandlerMarker)?.GetTypes()
                .Where(x => !x.IsAbstract && x.GetInterface(commandHandlerMarker.Name) != null).ToArray();
        }
    }
}