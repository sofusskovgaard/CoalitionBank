using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.TransactionsService
{
    [ProtoContract]
    public class GetTransactionsCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public int Page { get; set; } = 1;
        
        [ProtoMember(2)]
        public int PageSize { get; set; } = 10;
        
        [ProtoMember(3)]
        public string PartitionKey { get; set; }
    }
}