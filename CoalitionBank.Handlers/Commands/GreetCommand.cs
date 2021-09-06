using CoalitionBank.Handlers.Helpers;
using CoalitionBank.Handlers.Helpers.Markers;
using ProtoBuf;

namespace CoalitionBank.Handlers.Commands
{
    [ProtoContract]
    public class GreetCommand : ICommandMarker
    {
        [ProtoMember(1)]
        public string Message { get; set; }
    }
}