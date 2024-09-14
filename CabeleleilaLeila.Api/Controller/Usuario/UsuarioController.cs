using Microsoft.AspNetCore.Mvc;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Application.ApiManagement;
using CabeleleilaLeila.Application.Interfaces;

namespace CabeleleilaLeila.Api.Controllers;

[Route("api/[controller]")]
public class UsuarioController(IApiDataService apiDataService, IUsuarioService service) : BaseController<IUsuarioService, InputCreateUsuario, InputUpdateUsuario, OutputUsuario, InputIdentifierUsuario>(apiDataService, service) { }