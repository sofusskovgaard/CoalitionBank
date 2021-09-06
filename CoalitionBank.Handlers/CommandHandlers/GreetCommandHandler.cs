using CoalitionBank.Handlers.CommandResults;
using CoalitionBank.Handlers.Commands;
using CoalitionBank.Handlers.Helpers;

namespace CoalitionBank.Handlers.CommandHandlers
{
    public class GreetCommandHandler : BaseCommandHandler<GreetCommand, GreetCommandResult>
    {
        public override GreetCommandResult Invoke(GreetCommand command)
        {
            return new GreetCommandResult()
            {
                Message = $"Some asshole said: \"{command.Message}\""
            };
        }
    }
}