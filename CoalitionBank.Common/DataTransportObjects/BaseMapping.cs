using AutoMapper;
using CoalitionBank.Common.Entities;

namespace CoalitionBank.Common.DataTransportObjects
{
    public abstract class BaseMapping<TEntity, TDto> : Profile
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        public BaseMapping()
        {
            CreateMap<TEntity, TDto>()
                .ReverseMap();
        }
    }
}