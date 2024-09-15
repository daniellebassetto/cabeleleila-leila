using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Web.Services;

public class UserServiceClient(IHttpClientFactory factory) :  BaseServiceClient<InputCreateUser, InputUpdateUser, OutputUser, InputIdentifierUser>(factory), IUserServiceClient 
{
    public async Task<BaseServiceClientResponse<OutputUser>> Login(InputLoginUser input)
    {
        return await HandleRequestAsync<OutputUser>(HttpMethod.Post, $"{_nameService}/Login", input);
    }

    public async Task<BaseServiceClientResponse<bool>> SendLinkToRedefinePassword(InputSendLinkToRedefinePasswordUser input)
    {
        return await HandleRequestAsync<bool>(HttpMethod.Post, $"{_nameService}/SendLinkToRedefinePassword", input);
    }

    public async Task<BaseServiceClientResponse<bool>> RedefinePassword(InputRedefinePasswordUser input)
    {
        return await HandleRequestAsync<bool>(HttpMethod.Post, $"{_nameService}/RedefinePassword", input);
    }
}