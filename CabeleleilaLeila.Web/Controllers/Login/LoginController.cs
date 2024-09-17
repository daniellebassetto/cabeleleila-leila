using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CabeleleilaLeila.Web.Controllers;

public class LoginController(IUserServiceClient userServiceClient, Helpers.ISession session) : Controller
{
    private readonly IUserServiceClient _userServiceClient = userServiceClient;
    private readonly Helpers.ISession _session = session;

    public IActionResult Index()
    {
        if (_session.GetUserSession() != null)
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(InputLoginUser input)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var response = await _userServiceClient.Login(input);

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
        return RedirectToAction("Index");
    }

    public IActionResult SendLinkToRedefinePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendLinkToRedefinePassword(InputSendLinkToRedefinePasswordUser input)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var response = await _userServiceClient.SendLinkToRedefinePassword(input);

                if (response.Success)
                {
                    TempData["SuccessMessage"] = "Nova senha temporária enviada ao email cadastrado. Verifique sua caixa de entrada ou lixo eletrônico.";
                    return RedirectToAction("Index");
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

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(InputCreateUser input)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var response = await _userServiceClient.Create(input);

                if (response.Success)
                {
                    TempData["SuccessMessage"] = "Cadastro realizado com sucesso. Realize o login.";
                    return RedirectToAction("Index");
                }

                TempData["ErrorMessage"] = response.ErrorMessage!;
            }

            return View(input);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    public IActionResult RedefinePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RedefinePassword(InputRedefinePasswordUser input)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var response = await _userServiceClient.RedefinePassword(input);

                if (response.Success)
                {
                    TempData["SuccessMessage"] = "Senha atualizada com sucesso";
                }

                TempData["ErrorMessage"] = response.ErrorMessage!;
            }

            return View(input);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Erro: {ex.Message}";
            return RedirectToAction("Index", "Home");
        }
    }
}