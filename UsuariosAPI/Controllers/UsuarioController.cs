using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService, TokenService tokenService)
    {
        _usuarioService = cadastroService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDTO dto)
    {
        await _usuarioService.CadastrarUsuario(dto);
        return Ok("Usuário criado com sucesso");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(CreateLoginDTO dto)
    {
        var token = await _usuarioService.Login(dto);

        return Ok(token);
    }
}
