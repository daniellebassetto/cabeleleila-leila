using AutoMapper;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;

namespace CabeleleilaLeila.Application.Mapping;

public class MapperEntityOutput : Profile
{
    public MapperEntityOutput()
    {
        #region Usuario
        CreateMap<Usuario, OutputUsuario>().ReverseMap();
        #endregion
        
        #region Agendamento
        CreateMap<Agendamento, OutputAgendamento>().ReverseMap();
        #endregion
    }
}