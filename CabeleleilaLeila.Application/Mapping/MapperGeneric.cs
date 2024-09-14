using AutoMapper;

namespace CabeleleilaLeila.Application.Mapping;

public class MapperGeneric<TInput, TOutput> : Profile
{
    public MapperGeneric()
    {
        CreateMap<TInput, TOutput>().ReverseMap();
    }
}