using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Web.Services;

public interface IUsuarioServiceClient : IBaseServiceClient<InputCreateUsuario, InputUpdateUsuario, OutputUsuario, InputIdentifierUsuario> 
{
    Task<BaseServiceClientResponse<OutputUsuario>> Login(InputLoginUser input);
    Task<BaseServiceClientResponse<OutputUsuario>> SendLinkToRedefinePassword(string email);
}