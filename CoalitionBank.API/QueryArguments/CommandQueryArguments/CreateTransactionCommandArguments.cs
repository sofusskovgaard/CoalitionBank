using GraphQL.Types;

namespace CoalitionBank.API.QueryArguments.CommandQueryArguments
{
    public class CreateTransactionCommandArguments : GraphQL.Types.QueryArguments
    {
        public CreateTransactionCommandArguments()
        {
            Add(new QueryArgument<StringGraphType>() { Name = "SenderAccountId" });
            Add(new QueryArgument<StringGraphType>() { Name = "ReceiverAccountId" });
            Add(new QueryArgument<DecimalGraphType>() { Name = "Amount" });
        }
    }
}