using System;
using System.Linq;
using CoalitionBank.Handlers.Helpers.Markers;
using Microsoft.Extensions.DependencyInjection;

namespace CoalitionBank.Handlers.Helpers.Services
{
    public class CommandHandlerResolverService : ICommandHandlerResolverService
    {
        private IServiceProvider _services;

        public CommandHandlerResolverService()
        {
            var services = new ServiceCollection();

            foreach (var handlerType in CommandHandlerDiscovery.Discover())
            {
                var commandType = handlerType.BaseType.GenericTypeArguments[0];
                var commandResultType = handlerType.BaseType.GenericTypeArguments[1];
                services.AddTransient(handlerType,
                    handlerType.GetInterfaces().FirstOrDefault(x =>
                        x.GenericTypeArguments[0] == commandType && x.GenericTypeArguments[1] == commandResultType) ?? throw new InvalidOperationException());
            }

            _services = services.BuildServiceProvider();
        }

        public ICommandHandlerMarker Resolve(Type handlerType)
        {
            var commandType = handlerType.BaseType.GenericTypeArguments[0];
            var commandResultType = handlerType.BaseType.GenericTypeArguments[1];
            return (ICommandHandlerMarker)_services.GetRequiredService(handlerType.GetInterfaces().FirstOrDefault(x =>
                x.GenericTypeArguments[0] == commandType && x.GenericTypeArguments[1] == commandResultType) ?? throw new InvalidOperationException());
        }
    }
}