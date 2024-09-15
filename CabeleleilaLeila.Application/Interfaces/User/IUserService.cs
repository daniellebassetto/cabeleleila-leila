using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Application.Interfaces;

public interface IUserService : IBaseService<InputCreateUser, InputUpdateUser, OutputUser, InputIdentifierUser> 
{
    OutputUser Login(InputLoginUser input);
    bool SendLinkToRedefinePassword(InputSendLinkToRedefinePasswordUser input);
    bool RedefinePassword(InputRedefinePasswordUser input);
}