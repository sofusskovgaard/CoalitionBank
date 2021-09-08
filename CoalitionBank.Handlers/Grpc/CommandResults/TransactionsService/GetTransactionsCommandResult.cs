using System.Collections.Generic;
using CoalitionBank.Common.CommandResults;
using CoalitionBank.Common.DataTransportObjects.Transactions;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.TransactionsService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(TransactionDto))]
    public class GetTransactionsCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public IEnumerable<TransactionDto> Entities { get; set; }
    }
}