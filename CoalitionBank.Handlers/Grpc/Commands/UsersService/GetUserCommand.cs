using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.UsersService
{
    [ProtoContract]
    public class GetUserCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public string RowKey { get; set; }
        
        [ProtoMember(2)]
        public string PartitionKey { get; set; }
    }
}