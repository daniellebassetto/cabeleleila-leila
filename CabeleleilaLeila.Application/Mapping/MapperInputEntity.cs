using AutoMapper;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;

namespace CabeleleilaLeila.Application.Mapping;

public class MapperInputEntity : Profile
{
    public MapperInputEntity()
    {
        #region Usuario
        CreateMap<InputCreateUsuario, Usuario>().ReverseMap();
        #endregion

        #region Agendamento
        CreateMap<InputCreateAgendamento, Agendamento>().ReverseMap();
        #endregion
    }
}