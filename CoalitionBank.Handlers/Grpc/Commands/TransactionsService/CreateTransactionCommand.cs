using CoalitionBank.Common.DataTransportObjects.Transactions;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.TransactionsService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(TransactionDto))]
    [ProtoInclude(2, typeof(TransactionDto))]
    public class CreateTransactionCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public TransactionDto SenderTransaction { get; set; }
        
        [ProtoMember(2)]
        public TransactionDto ReceiverTransaction { get; set; }
    }
}