using CTRLInvesting.Api.Data;
using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Model.Usuario;
using Microsoft.EntityFrameworkCore;

namespace CTRLInvesting.Api.Services;

public class UserService : IUserService
{
    private readonly IAuthService _authService;
    private readonly DataContext _context;

    public UserService(IAuthService authService, DataContext context)
    {
        _authService = authService;
        _context = context;
    }


    public string AuthenticateUser(string Usuario, string Password)
    {
        return _authService.Authenticate(Usuario, Password);
    }

    public bool CheckEmailUser(RegisterModel registerUsuario)
    {
        return _context.Usuario.Any(x => x.UserName.ToLower() == registerUsuario.Usuario.ToLower() || x.Email.ToLower() == registerUsuario.Email.ToLower());
    }


    public async void CreateUser(Usuario usuario)
    {
        await _context.Usuario.AddAsync(usuario);
        _context.SaveChanges();
    }

    public async Task UpdateUser(Usuario usuario)
    {
        _context.Usuario.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<Usuario> GetEmailUnique(string email)
    {
        return await _context.Usuario.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Usuario> GetUserByHash(string hash)
    {
        return await _context.Usuario.FirstOrDefaultAsync(x => x.JwtToken == hash);
    }

    public async Task<Usuario> GetUserByHashSpecific(string hash)
    {
        return await _context.Usuario.FirstOrDefaultAsync(x => x.JwtToken.Contains(hash));
    }
    
    public async Task<Usuario> GetUsuarioUnique(string usuario)
    {
        return await _context.Usuario.FirstOrDefaultAsync(x => x.UserName == usuario);
    }

}
