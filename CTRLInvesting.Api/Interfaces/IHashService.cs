namespace CTRLInvesting.Api.Interfaces;

public interface IHashService
{
    string GenerateHashPassword(string password, string salt);
}
