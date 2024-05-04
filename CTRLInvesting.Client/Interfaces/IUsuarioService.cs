using CTRLInvesting.Model.Usuario;

namespace CTRLInvesting.Client.Interfaces;

public interface IUsuarioService
{
    Task<bool> GetUniqueUserByEmailAsync(string email);
    Task<Usuario> GetUserByEmailAsync(string email);
    Task<bool> GetUserByUsuarioAsync(string usuario);
    Task<Usuario> GetUserByHashAsync(string hash);
    Task<string> Login(LoginModel model);
    Task<string> Register(RegisterModel model);
    Task<string> ResetSenha(UserResetModel model);
}
