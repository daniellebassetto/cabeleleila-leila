using Microsoft.AspNetCore.Mvc;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Application.ApiManagement;
using CabeleleilaLeila.Application.Interfaces;

namespace CabeleleilaLeila.Api.Controllers;

[Route("api/[controller]")]
public class UsuarioController(IApiDataService apiDataService, IUsuarioService service) : BaseController<IUsuarioService, InputCreateUsuario, InputUpdateUsuario, OutputUsuario, InputIdentifierUsuario>(apiDataService, service) 
{
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseApi<OutputUsuario>>> Update([FromBody] InputLoginUser input)
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
}