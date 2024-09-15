using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Web.Services;

public interface IUserServiceClient : IBaseServiceClient<InputCreateUser, InputUpdateUser, OutputUser, InputIdentifierUser>
{
    Task<BaseServiceClientResponse<OutputUser>> Login(InputLoginUser input);
    Task<BaseServiceClientResponse<bool>> SendLinkToRedefinePassword(InputSendLinkToRedefinePasswordUser input);
    Task<BaseServiceClientResponse<bool>> RedefinePassword(InputRedefinePasswordUser input);
}