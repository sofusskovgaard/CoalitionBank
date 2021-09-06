using CoalitionBank.Common.Entities;
using GraphQL.Types;

namespace CoalitionBank.API.Types
{
    public abstract class BaseType<T> : ObjectGraphType<T> where T : BaseEntity
    {
        protected BaseType()
        {
            Field(x => x.RowKey);
            Field(x => x.PartitionKey);
        }
    }
}