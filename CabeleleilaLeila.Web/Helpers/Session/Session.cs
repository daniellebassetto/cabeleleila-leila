using CabeleleilaLeila.Arguments;
using Newtonsoft.Json;

namespace CabeleleilaLeila.Web.Helpers;

public class Session(IHttpContextAccessor httpContextAccessor) : ISession
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public void CreateUserSession(string userSerialize)
    {
        _httpContextAccessor.HttpContext!.Session.SetString("loggedUserSession", userSerialize);
    }

    public OutputUser? GetUserSession()
    {
        string userSession = _httpContextAccessor.HttpContext!.Session.GetString("loggedUserSession")!;

        if (string.IsNullOrEmpty(userSession))
            return null;

        return JsonConvert.DeserializeObject<OutputUser>(userSession);
    }

    public void RemoveUserSession()
    {
        _httpContextAccessor.HttpContext!.Session.Remove("loggedUserSession");
    }
}