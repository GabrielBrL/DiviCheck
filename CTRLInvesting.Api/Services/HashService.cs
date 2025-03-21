using System.Security.Cryptography;
using System.Text;
using CTRLInvesting.Api.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CTRLInvesting.Api.Services;

public class HashService : IHashService
{
    public string GenerateHashPassword(string password, string salt)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
        string hashed = Convert.ToBase64String(
            KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            )
        );
        return hashed;
    }
}
