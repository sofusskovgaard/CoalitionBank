using AutoMapper;
using CoalitionBank.Common.Entities;

namespace CoalitionBank.Common.DataTransportObjects
{
    public abstract class BaseMapping<TEntity, TDto, TSensitiveDto> : Profile
        where TEntity : BaseEntity
        where TDto : BaseDto
        where TSensitiveDto : TDto
    {
        public BaseMapping()
        {
            CreateMap<TEntity, TDto>()
                .ReverseMap();

            CreateMap<TEntity, TSensitiveDto>()
                .ReverseMap();

            CreateMap<TSensitiveDto, TDto>()
                .ReverseMap();
        }
    }
}