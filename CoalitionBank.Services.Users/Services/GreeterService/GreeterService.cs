using System.Threading.Tasks;
using CoalitionBank.Handlers.CommandResults;
using CoalitionBank.Handlers.Commands;

namespace CoalitionBank.Services.Users.Services.GreeterService
{
    public class GreeterService : IGreeterService
    {
        public Task<GreetCommandResult> Greet(GreetCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}