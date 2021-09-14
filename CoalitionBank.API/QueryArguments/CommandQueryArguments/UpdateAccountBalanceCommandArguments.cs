using GraphQL.Types;

namespace CoalitionBank.API.QueryArguments.CommandQueryArguments
{
    public class UpdateAccountBalanceCommandArguments : GraphQL.Types.QueryArguments
    {
        public UpdateAccountBalanceCommandArguments()
        {
            Add(new QueryArgument<StringGraphType>() { Name = "Id" });
            Add(new QueryArgument<StringGraphType>() { Name = "PartitionKey" });
        }
    }
}