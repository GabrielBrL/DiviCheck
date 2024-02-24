using CTRLInvesting.Model.Usuario;

namespace CTRLInvesting.Api.Interfaces;

public interface IUserService
{
    string AuthenticateUser(string Usuario, string Password);
    bool CheckEmailUser(RegisterModel registerUsuario);

    void CreateUser(Usuario usuario);
    Task<Usuario> GetUsuarioUnique(string usuario);
    Task<Usuario> GetEmailUnique(string email);
}
