using GraphQL.Types;

namespace CoalitionBank.API.QueryArguments
{
    public class PaginatedQueryArguments : GraphQL.Types.QueryArguments
    {
        public PaginatedQueryArguments()
        {
            Add(new QueryArgument<IntGraphType>() { Name = "PartitionKey", DefaultValue = null });
            Add(new QueryArgument<IntGraphType>() { Name = "Page", DefaultValue = 1 });
            Add(new QueryArgument<IntGraphType>() { Name = "PageSize", DefaultValue = 10 });
        }
    }
}