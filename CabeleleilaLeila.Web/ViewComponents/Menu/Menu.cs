using CabeleleilaLeila.Arguments;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CabeleleilaLeila.Web.ViewComponents;

public class Menu : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        string? userSession = HttpContext.Session.GetString("loggedUserSession");

        if (string.IsNullOrEmpty(userSession))
            return Content("Usuário não logado.");

        OutputUser user = JsonConvert.DeserializeObject<OutputUser>(userSession)!;

        return View(user);
    }
}