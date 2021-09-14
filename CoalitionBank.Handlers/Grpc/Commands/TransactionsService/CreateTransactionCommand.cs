using CoalitionBank.Common.Commands;
using CoalitionBank.Common.DataTransportObjects.Transactions;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.TransactionsService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(TransactionDto))]
    public class CreateTransactionCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public TransactionDto Entity { get; set; }
    }
}