using Microsoft.AspNetCore.Mvc;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Application.ApiManagement;
using CabeleleilaLeila.Application.Interfaces;

namespace CabeleleilaLeila.Api.Controllers;

[Route("api/[controller]")]
public class UserController(IApiDataService apiDataService, IUserService service) : BaseController<IUserService, InputCreateUser, InputUpdateUser, OutputUser, InputIdentifierUser>(apiDataService, service) 
{
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseApi<OutputUser>>> Update([FromBody] InputLoginUser input)
    {
        try
        {
            var result = _service!.Login(input);
            if (result == null)
                return NotFound(new BaseResponseApi<string> { ErrorMessage = "Item não encontrado." });

            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("SendLinkToRedefinePassword")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseApi<bool>>> SendLinkToRedefinePassword([FromBody] InputSendLinkToRedefinePasswordUser input)
    {
        try
        {
            var result = _service!.SendLinkToRedefinePassword(input);
            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("RedefinePassword")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseApi<bool>>> RedefinePassword([FromBody] InputRedefinePasswordUser input)
    {
        try
        {
            var result = _service!.RedefinePassword(input);
            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
}