using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Web.Helpers;

public interface ISession
{
    void CreateUserSession(string userSerialize);
    void RemoveUserSession();
    OutputUsuario? GetUserSession();
}