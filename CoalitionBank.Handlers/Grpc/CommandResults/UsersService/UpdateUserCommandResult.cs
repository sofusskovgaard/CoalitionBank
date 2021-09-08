using CoalitionBank.Common.CommandResults;
using CoalitionBank.Common.DataTransportObjects.Users;
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