using CTRLInvesting.Model.Usuario;

namespace CTRLInvesting.Api.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(Usuario user);
}
