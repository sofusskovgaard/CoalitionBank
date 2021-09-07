using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.UsersService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(UserDto))]
    public class CreateUserCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public UserDto Entity { get; set; }
    }
}