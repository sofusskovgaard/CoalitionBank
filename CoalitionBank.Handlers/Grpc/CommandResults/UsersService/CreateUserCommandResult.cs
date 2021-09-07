using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.UsersService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(SensitiveUserDto))]
    public class CreateUserCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public SensitiveUserDto Entity { get; set; }
    }
}