using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.UsersService
{
    [ProtoContract]
    public class GetUsersCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public int Page { get; set; } = 1;
        
        [ProtoMember(2)]
        public int PageSize { get; set; } = 10;
    }
}