using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Web.Services;

public class UsuarioServiceClient(IHttpClientFactory factory) :  BaseServiceClient<InputCreateUsuario, InputUpdateUsuario, OutputUsuario, InputIdentifierUsuario>(factory), IUsuarioServiceClient 
{
    public async Task<BaseServiceClientResponse<OutputUsuario>> Login(InputLoginUser input)
    {
        return await HandleRequestAsync<OutputUsuario>(HttpMethod.Post, $"{_nameService}/Login", input);
    }

    public async Task<BaseServiceClientResponse<OutputUsuario>> SendLinkToRedefinePassword(string email)
    {
        return await HandleRequestAsync<OutputUsuario>(HttpMethod.Post, $"{_nameService}/SendLinkToRedefinePassword/{email}", null);
    }
}