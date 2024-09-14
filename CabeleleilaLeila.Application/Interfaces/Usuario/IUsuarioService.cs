using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Application.Interfaces;

public interface IUsuarioService : IBaseService<InputCreateUsuario, InputUpdateUsuario, OutputUsuario, InputIdentifierUsuario> 
{
    OutputUsuario Login(InputLoginUser input);
}