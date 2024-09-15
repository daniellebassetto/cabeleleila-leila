using AutoMapper;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;

namespace CabeleleilaLeila.Application.Mapping;

public class MapperInputEntity : Profile
{
    public MapperInputEntity()
    {
        #region User
        CreateMap<InputCreateUser, User>().ReverseMap();
        #endregion

        #region Scheduling
        CreateMap<InputCreateScheduling, Scheduling>().ReverseMap();
        #endregion
    }
}