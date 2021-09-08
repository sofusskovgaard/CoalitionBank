using CoalitionBank.Common.DataTransportObjects;
using CoalitionBank.Common.Entities;
using GraphQL.Types;

namespace CoalitionBank.API.Types
{
    public abstract class BaseType<T> : ObjectGraphType<T> where T : BaseDto
    {
        protected BaseType()
        {
            Field(x => x.Id);
            Field(x => x.PartitionKey);
            Field(x => x.ETag);
            Field(x => x.CreatedAt);
        }
    }
}