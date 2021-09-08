using CoalitionBank.Common.CommandResults;
using CoalitionBank.Common.Commands;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using CoalitionBank.Handlers.Helpers;

namespace CoalitionBank.Handlers.Grpc.Helpers
{
    public abstract class GrpcCommandHandler<TCommand, TCommandResult> : BaseCommandHandler<TCommand, TCommandResult>,
        IGrpcCommandHandlerMarker
        where TCommand : IGrpcCommandMarker
        where TCommandResult : IGrpcCommandResultMarker
    {
    }
}