using GraphQL.Types;

namespace CoalitionBank.API.QueryArguments.CommandQueryArguments
{
    public class CreateAccountCommandArguments : GraphQL.Types.QueryArguments
    {
        public CreateAccountCommandArguments()
        {
            Add(new QueryArgument<StringGraphType>() { Name = "Title" });
            Add(new QueryArgument<StringGraphType>() { Name = "OwnerId" });
        }
    }
}