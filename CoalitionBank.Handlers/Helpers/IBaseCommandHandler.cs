using System.Threading.Tasks;
using CoalitionBank.Handlers.Helpers.Markers;

namespace CoalitionBank.Handlers.Helpers
{
    public interface IBaseCommandHandler<TCommand, TCommandResult> : ICommandHandlerMarker
        where TCommand : ICommandMarker
        where TCommandResult : ICommandResultMarker
    {
        Task<TCommandResult> Invoke(TCommand command);
    }
}