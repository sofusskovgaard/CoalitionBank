using CoalitionBank.Common.Commands;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.AccountsService
{
    [ProtoContract]
    [ProtoInclude(1, typeof(AccountDto))]
    public class UpdateAccountCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public AccountDto Entity { get; set; }
    }
}