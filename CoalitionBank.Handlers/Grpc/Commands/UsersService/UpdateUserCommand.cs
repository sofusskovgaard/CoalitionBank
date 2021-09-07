using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.UsersService
{
    [ProtoContract]
    public class UpdateUserCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public UserDto Entity { get; set; }
    }
}