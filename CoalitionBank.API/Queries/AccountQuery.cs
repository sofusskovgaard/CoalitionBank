using System;
using CoalitionBank.API.Helpers;
using CoalitionBank.API.QueryArguments;
using CoalitionBank.API.Types;
using GraphQL.Types;

namespace CoalitionBank.API.Queries
{
    public class AccountQuery : ObjectGraphType<object>, IGraphQueryMarker
    {
        public AccountQuery()
        {
            Field<AccountType>("account", arguments: new SpecificQueryArguments(),
                resolve: context => throw new NotImplementedException());
            
            Field<ListGraphType<AccountType>>("accounts", arguments: new PaginatedQueryArguments(),
                resolve: context => throw new NotImplementedException());
        }
    }
}