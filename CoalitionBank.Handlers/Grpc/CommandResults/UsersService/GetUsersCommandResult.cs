using System.Collections.Generic;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.UsersService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(UserDto))]
    public class GetUsersCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public IEnumerable<UserDto> Users { get; set; }
    }
}