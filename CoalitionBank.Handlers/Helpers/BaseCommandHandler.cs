using System.Threading.Tasks;
using CoalitionBank.Handlers.Helpers.Markers;

namespace CoalitionBank.Handlers.Helpers
{
    public abstract class BaseCommandHandler<TCommand, TCommandResult> : IBaseCommandHandler<TCommand, TCommandResult>
        where TCommand : ICommandMarker
        where TCommandResult : ICommandResultMarker
    {
        public abstract Task<TCommandResult> Invoke(TCommand command);
    }
}