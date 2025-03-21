using CTRLInvesting.Api.Data;
using CTRLInvesting.Api.Interfaces;

namespace CTRLInvesting.Api.Services;

public class AuthService : IAuthService
{
    private readonly IHashService _hashService;
    private readonly ITokenService _tokenService;
    private readonly DataContext _context;

    public AuthService(IHashService hashService, DataContext context, ITokenService tokenService)
    {
        _hashService = hashService;
        _context = context;
        _tokenService = tokenService;
    }

    public bool ValidateCredentials(string enteredPassword, string storedHashedPassword, string salt)
    {
        string hashedEnteredPassword = _hashService.GenerateHashPassword(enteredPassword, salt);

        return hashedEnteredPassword == storedHashedPassword;
    }

    public string Authenticate(string username, string password)
    {
        var user = _context.Usuario.FirstOrDefault(x => x.UserName.Equals(username) || x.Email.Equals(username));

        if (user != null && this.ValidateCredentials(password, user.Password, user.Salt))
        {            
            return _tokenService.GenerateJwtToken(user);
        }

        return string.Empty;
    }
}
