using CoalitionBank.Common.Commands;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.AccountsService
{
    [ProtoContract]
    public class GetAccountCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public string Id { get; set; }
        
        [ProtoMember(2)]
        public string PartitionKey { get; set; }
    }
}