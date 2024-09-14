using Microsoft.AspNetCore.Mvc;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Application.ApiManagement;
using CabeleleilaLeila.Application.Interfaces;

namespace CabeleleilaLeila.Api.Controllers;

[Route("api/[controller]")]
public class AgendamentoController(IApiDataService apiDataService, IAgendamentoService service) : BaseController<IAgendamentoService, InputCreateAgendamento, InputUpdateAgendamento, OutputAgendamento, InputIdentifierAgendamento>(apiDataService, service) 
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<bool>>> Delete([FromRoute] long id)
    {
        return base.Delete(id);
    }
}