using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.UsersService
{
    [ProtoContract]
    public class UpdateUserCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public UserDto Entity { get; set; }
    }
}