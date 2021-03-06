using CoalitionBank.Common.CommandResults;
using CoalitionBank.Common.DataTransportObjects.Transactions;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.TransactionsService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(TransactionDto))]
    public class UpdateTransactionCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public TransactionDto Entity { get; set; }
    }
}