using CoalitionBank.Common.CommandResults;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.AccountsService
{
    [ProtoContract]
    public class DeleteAccountCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public bool Success { get; set; }
    }
}