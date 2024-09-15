using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CabeleleilaLeila.Controllers;

public class LoginController(IUserServiceClient userServiceClient, Web.Helpers.ISession session) : Controller
{
    private readonly IUserServiceClient _userServiceClient = userServiceClient;
    private readonly Web.Helpers.ISession _session = session;

    public IActionResult Index()
    {
        if (_session.GetUserSession() != null)
            return RedirectToAction("Index", "Home");
        return View();
    }

    public IActionResult RedefinePassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Enter(InputLoginUser input)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var response = _userServiceClient.Login(input).Result;

                if (response.Success)
                {
                    var user = response.Data;
                    _session.CreateUserSession(JsonConvert.SerializeObject(user));
                    return RedirectToAction("Index", "Home");
                }

                TempData["ErrorMessage"] = response.ErrorMessage!;
                return RedirectToAction("Index");
            }

            return View("Index");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    public IActionResult Exit()
    {
        _session.RemoveUserSession();
        return RedirectToAction("Index", "Login");
    }

    [HttpPost]
    public IActionResult SendLinkToRedefinePassword(InputSendLinkToRedefinePasswordUser input)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var response = _userServiceClient.SendLinkToRedefinePassword(input).Result;

                if (response.Success)
                {
                    return RedirectToAction("Index", "Login");
                }

                TempData["ErrorMessage"] = response.ErrorMessage!;
            }

            return View("Index");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }
}