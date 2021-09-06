using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.Handlers.Helpers.Utilities
{
    public static class CommandHandlerResolver
    {
        public static TCommandHandler Resolve<TCommandHandler>(this IServiceScope scope)
        {
            var handlerType = typeof(TCommandHandler);
            var services = scope.ServiceProvider;

            var commandType = handlerType.BaseType.GenericTypeArguments[0];
            var commandResultType = handlerType.BaseType.GenericTypeArguments[1];
            return (TCommandHandler)services.GetRequiredService(handlerType.GetInterfaces().FirstOrDefault(x =>
                                                                    x.IsGenericType &&
                                                                    x.GenericTypeArguments[0] == commandType &&
                                                                    x.GenericTypeArguments[1] ==
                                                                    commandResultType) ??
                                                                throw new InvalidOperationException());
        }
    }
}