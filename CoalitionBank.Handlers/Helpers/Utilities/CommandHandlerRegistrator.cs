using System;
using System.Linq;
using CoalitionBank.Handlers.Helpers.Discovery;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.Handlers.Helpers.Utilities
{
    public static class CommandHandlerRegistrator
    {
        public static void AddCommandHandlers<TCommandHandlerMarker>(this IServiceCollection services)
        {
            foreach (var handlerType in CommandHandlerDiscovery.Discover(typeof(TCommandHandlerMarker)))
            {
                var commandType = handlerType.BaseType.GenericTypeArguments[0];
                var commandResultType = handlerType.BaseType.GenericTypeArguments[1];
                services.AddTransient(handlerType.GetInterfaces().FirstOrDefault(x => x.IsGenericType &&
                                          x.GenericTypeArguments[0] == commandType &&
                                          x.GenericTypeArguments[1] == commandResultType) ??
                                      throw new InvalidOperationException(), handlerType);
            }
        }
    }
}