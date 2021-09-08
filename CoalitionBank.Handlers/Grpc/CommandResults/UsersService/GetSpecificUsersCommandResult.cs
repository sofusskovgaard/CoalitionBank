using System.Collections.Generic;
using CoalitionBank.Common.CommandResults;
using CoalitionBank.Common.DataTransportObjects.Users;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.UsersService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(UserDto))]
    public class GetSpecificUsersCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public IEnumerable<UserDto> Entities { get; set; }
    }
}