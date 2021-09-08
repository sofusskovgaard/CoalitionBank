using System.Collections.Generic;
using CoalitionBank.Common.CommandResults;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.AccountsService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(AccountDto))]
    public class GetAccountsCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public IEnumerable<AccountDto> Entities { get; set; }
    }
}