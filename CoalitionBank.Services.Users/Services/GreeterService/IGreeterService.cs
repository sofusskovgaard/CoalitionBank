using System.Threading.Tasks;
using CoalitionBank.Handlers.CommandResults;
using CoalitionBank.Handlers.Commands;
using ProtoBuf;
using ProtoBuf.Grpc.Configuration;

namespace CoalitionBank.Services.Users.Services.GreeterService
{
    [Service]
    public interface IGreeterService
    {
        [Operation]
        Task<GreetCommandResult> Greet(GreetCommand command);
    }
}