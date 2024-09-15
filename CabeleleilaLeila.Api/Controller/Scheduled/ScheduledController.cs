using Microsoft.AspNetCore.Mvc;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Application.ApiManagement;
using CabeleleilaLeila.Application.Interfaces;

namespace CabeleleilaLeila.Api.Controllers;

[Route("api/[controller]")]
public class ScheduledController(IApiDataService apiDataService, IScheduledService service) : BaseController<IScheduledService, InputCreateScheduled, InputUpdateScheduled, OutputScheduled, InputIdentifierScheduled>(apiDataService, service) 
{
    [HttpPost("Cancel/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseApi<bool>>> Cancel([FromRoute] long id)
    {
        try
        {
            var result = _service!.Cancel(id);
            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("Confirm/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseApi<bool>>> Confirm([FromRoute] long id)
    {
        try
        {
            var result = _service!.Confirm(id);
            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<bool>>> Delete([FromRoute] long id)
    {
        return base.Delete(id);
    }
}