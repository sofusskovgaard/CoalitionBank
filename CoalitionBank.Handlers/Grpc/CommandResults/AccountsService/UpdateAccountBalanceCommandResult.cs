using CoalitionBank.Common.CommandResults;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.AccountsService
{
    [ProtoContract]
    [ProtoInclude(2, typeof(AccountDto))]
    public class UpdateAccountBalanceCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public bool Changed { get; set; }
        
        [ProtoMember(2)]
        public AccountDto? Entity { get; set; }
    }
}