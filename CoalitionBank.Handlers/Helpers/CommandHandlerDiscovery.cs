using System;
using System.Linq;
using System.Reflection;
using CoalitionBank.Handlers.Helpers.Markers;
using Google.Protobuf.Reflection;

namespace CoalitionBank.Handlers.Helpers
{
    public static class CommandHandlerDiscovery
    {
        public static Type[] Discover()
        {
            return Assembly.GetAssembly(typeof(ICommandHandlerMarker)).GetTypes()
                .Where(x => x.GetInterface(nameof(ICommandHandlerMarker)) != null).ToArray();
        }
    }
}