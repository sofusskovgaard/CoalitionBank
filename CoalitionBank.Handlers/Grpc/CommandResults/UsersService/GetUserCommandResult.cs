using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.UsersService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(UserDto))]
    public class GetUserCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public UserDto User { get; set; }
    }
}