using GraphQL.Types;

namespace CoalitionBank.API.QueryArguments
{
    public class SpecificQueryArguments : GraphQL.Types.QueryArguments
    {
        public SpecificQueryArguments()
        {
            Add(new QueryArgument<StringGraphType>() { Name = "Id" });
            Add(new QueryArgument<StringGraphType>() { Name = "PartitionKey" });
        }
    }
}