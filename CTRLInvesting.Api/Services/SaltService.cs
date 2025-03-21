using System.Security.Cryptography;

namespace CTRLInvesting.Api.Services;

public class SaltService
{
    public static string GenerateSalt(int lenghtBytes)
    {
        byte[] saltBytes = new byte[lenghtBytes];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        
        return Convert.ToBase64String(saltBytes);
    }
}
