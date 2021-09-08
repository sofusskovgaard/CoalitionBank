using CoalitionBank.Common.CommandResults;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.CommandResults.AccountsService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(AccountDto))]
    public class UpdateAccountCommandResult : IGrpcCommandResultMarker
    {
        [ProtoMember(1)]
        public AccountDto Entity { get; set; }
    }
}