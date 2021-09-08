using System.Collections.Generic;
using CoalitionBank.Common.Commands;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.UsersService
{
    [ProtoContract]
    public class GetSpecificUsersCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public IEnumerable<string> Ids { get; set; }
    }
}