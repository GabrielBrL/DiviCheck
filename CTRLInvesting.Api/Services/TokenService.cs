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

    public static long GetTokenExpirationTime(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(token);
        var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
        var ticks = long.Parse(tokenExp);
        return ticks;
    }

    public static bool CheckTokenIsValid(string token)
    {
        var tokenTicks = GetTokenExpirationTime(token);
        var tokenDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;

        var now = DateTime.Now.ToUniversalTime();

        var valid = tokenDate >= now;

        return valid;
    }
}
