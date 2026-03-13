using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("Acesso")]
public class AcessoController : ControllerBase
{
    private IAuthorizationService _authorizationService;

    public AcessoController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }
    [HttpGet]
    [Authorize(Policy = "IdadeMinima")]
    public async Task<IActionResult> Get()
    {
        var resultado = await _authorizationService.AuthorizeAsync(User, "IdadeMinima");

        if (resultado.Succeeded)
        {
            return Ok("Acesso permitido pela política");
        }

        return Unauthorized("A política de idade falhou.");
    }
}
