namespace CTRLInvesting.Api.Interfaces;

public interface IAuthService
{
    bool ValidateCredentials(string enteredPassword, string storedHashedPassword, string salt);
    string Authenticate(string username, string password);
}
