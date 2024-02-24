using CTRLInvesting.Model.Usuario;

namespace CTRLInvesting.Client.Interfaces;

public interface IUsuarioService
{
    Task<bool> GetUserByEmailAsync(string email);
    Task<bool> GetUserByUsuarioAsync(string usuario);
    Task<string> Login(LoginModel model);
    Task<string> Register(RegisterModel model);
}
