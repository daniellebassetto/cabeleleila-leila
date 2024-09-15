using AutoMapper;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;

namespace CabeleleilaLeila.Application.Mapping;

public class MapperEntityOutput : Profile
{
    public MapperEntityOutput()
    {
        #region User
        CreateMap<User, OutputUser>().ReverseMap();
        #endregion

        #region Scheduled
        CreateMap<Scheduled, OutputScheduled>().ReverseMap();
        #endregion
    }
}