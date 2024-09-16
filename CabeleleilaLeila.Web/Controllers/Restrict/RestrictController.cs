using Microsoft.AspNetCore.Mvc;

namespace CabeleleilaLeila.Web.Controllers;

public class RestrictController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}