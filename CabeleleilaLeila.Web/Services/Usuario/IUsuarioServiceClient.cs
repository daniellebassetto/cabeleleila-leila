using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Web.Services;

public interface IUsuarioServiceClient : IBaseServiceClient<InputCreateUsuario, InputUpdateUsuario, OutputUsuario> 
{
    Task<BaseServiceClientResponse<OutputUsuario>> Login(InputLoginUser input);
}