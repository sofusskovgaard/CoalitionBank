using CoalitionBank.Common.Commands;
using ProtoBuf;

namespace CoalitionBank.Handlers.Grpc.Commands.UsersService
{
    [ProtoContract]
    public class DeleteUserCommand : IGrpcCommandMarker
    {
        [ProtoMember(1)]
        public string Id { get; set; }
        
        [ProtoMember(2)]
        public string PartitionKey { get; set; }
    }
}