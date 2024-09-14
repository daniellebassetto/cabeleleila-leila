using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Web.Helpers;
using CabeleleilaLeila.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CabeleleilaLeila.Controllers;

public class LoginController(IUsuarioServiceClient usuarioServiceClient, Web.Helpers.ISession session, IEmail email) : Controller
{
    private readonly IUsuarioServiceClient _usuarioServiceClient = usuarioServiceClient;
    private readonly Web.Helpers.ISession _session = session;
    private readonly IEmail _email = email;

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
                var response = _usuarioServiceClient.Login(input).Result;

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

    //[HttpPost]
    //public IActionResult SendLinkToRedefinePassword(RedefinePasswordLoginModel redefinePasswordModel)
    //{
    //    try
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            UserModel user = _usuarioServiceClient.GetLoginAndEmail(redefinePasswordModel.Login, redefinePasswordModel.Email);

    //            if (user != null)
    //            {
    //                string newPassword = user.GenerateNewPassword();
    //                string message = $"Sua nova senha é: {newPassword}";
    //                bool emailSent = _email.Send(user.Email, "CabeleleilaLeila - Nova Senha", message);

    //                if (emailSent)
    //                {
    //                    _usuarioServiceClient.Update(user);
    //                    TempData["SuccessMessage"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
    //                }
    //                else
    //                {
    //                    TempData["ErrorMessage"] = $"Ocorreu um erro ao enviar o e-mail. Tente novamente.";
    //                }

    //                return RedirectToAction("Index", "Login");
    //            }

    //            TempData["ErrorMessage"] = $"Não foi possível redefinir sua senha. Verifique os dados informados.";
    //        }

    //        return View("Index");
    //    }
    //    catch (Exception ex)
    //    {
    //        TempData["ErrorMessage"] = $"Erro: {ex.Message}";
    //        return RedirectToAction("Index");
    //    }
    //}
}