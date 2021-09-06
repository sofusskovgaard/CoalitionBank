using System;
using CoalitionBank.Handlers.Helpers.Markers;

namespace CoalitionBank.Handlers.Helpers.Services
{
    public interface ICommandHandlerResolverService
    {
        ICommandHandlerMarker Resolve(Type handlerType);
    }
}