using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.UsersService
{
    [ProtoContract]
    public class DeleteUserCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public bool Success { get; set; }
    }
}