using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CTRLInvesting.Api.Data;
using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Model.Configs;
using CTRLInvesting.Model.Usuario;
using Microsoft.IdentityModel.Tokens;

namespace CTRLInvesting.Api.Services;

public class TokenService : ITokenService
{
    private readonly DataContext _context;

    public TokenService(DataContext context)
    {
        _context = context;
    }

    public string GenerateJwtToken(Usuario user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.ChaveSecreta));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        string role = _context.Roles.First(x => x.IdRole == user.IdRole).Role;
        var claims = new List<Claim>
        {
            new Claim("IdUsuario", user.IdUsuario.ToString()),
            new Claim("Username", user.UserName),
            new Claim("Email", user.Email),
            new Claim(ClaimTypes.Role, role),
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),            
            signingCredentials: credentials
        );

        return tokenHandler.WriteToken(token);
    }
}
