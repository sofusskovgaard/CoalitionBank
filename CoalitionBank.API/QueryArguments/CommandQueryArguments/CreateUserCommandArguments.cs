using System.Linq;
using System.Reflection;
using CoalitionBank.API.Types;
using GraphQL.Types;

namespace CoalitionBank.API.QueryArguments.CommandQueryArguments
{
    public class CreateUserCommandArguments : GraphQL.Types.QueryArguments
    {
        public CreateUserCommandArguments()
        {
            Add(new QueryArgument<StringGraphType>() { Name = "Firstname" });
            Add(new QueryArgument<StringGraphType>() { Name = "Lastname" });
            Add(new QueryArgument<StringGraphType>() { Name = "Email" });
            Add(new QueryArgument<StringGraphType>() { Name = "Password" });
        }
    }
}