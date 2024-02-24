using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Api.Services;
using CTRLInvesting.Model.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CTRLInvesting.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly IHashService _hashService;

    public UsuarioController(IUserService userService, ITokenService tokenService, IHashService hashService)
    {
        _userService = userService;
        _tokenService = tokenService;
        _hashService = hashService;
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
        string token = _userService.AuthenticateUser(loginModel.Usuario, loginModel.Password);
        if (!string.IsNullOrEmpty(token))
            return Ok(token);
        return Unauthorized();
    }
    [HttpPost("cadastro")]
    public async Task<string> Register([FromBody] RegisterModel registerUsuario)
    {
        if (_userService.CheckEmailUser(registerUsuario))
            return "Erro";
        if (!string.IsNullOrEmpty(registerUsuario.Usuario)
        && !string.IsNullOrEmpty(registerUsuario.Password)
        && !string.IsNullOrEmpty(registerUsuario.Email)
        && !string.IsNullOrEmpty(registerUsuario.IdRole.ToString()))
        {
            var salt = SaltService.GenerateSalt(16);
            var passwordHashed = _hashService.GenerateHashPassword(registerUsuario.Password, salt);
            Usuario usuario = new Usuario
            {
                UserName = registerUsuario.Usuario,
                Password = passwordHashed,
                Email = registerUsuario.Email,
                Salt = salt,
                IdRole = registerUsuario.IdRole
            };
            usuario.JwtToken = _tokenService.GenerateJwtToken(usuario);
            _userService.CreateUser(usuario);
            registerUsuario.Password = string.Empty;
            return registerUsuario.Usuario;
        }
        return "Erro";
    }
    [HttpGet("usuario={usuario}")]
    public async Task<bool> GetUsuarioUnique(string usuario)
    {
        return await _userService.GetUsuarioUnique(usuario) == null;
    }
    [HttpGet("email={email}")]
    public async Task<bool> GetEmailUnique(string email)
    {
        return await _userService.GetEmailUnique(email) == null;
    }
}
