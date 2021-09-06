using CoalitionBank.Handlers.Helpers;
using CoalitionBank.Handlers.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.CommandResults
{
    [ProtoContract]
    public class GreetCommandResult : ICommandResultMarker
    {
        [ProtoMember(1)]
        public string Message { get; set; }
    }
}