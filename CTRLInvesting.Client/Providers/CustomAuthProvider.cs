using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace CTRLInvesting.Client.Providers;

public class CustomAuthProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorageService;

    public CustomAuthProvider(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var jwt = await _localStorageService.GetItemAsync<string>("token");
        if (string.IsNullOrEmpty(jwt) || isValidateExpiredToken(jwt))
        {
            return new AuthenticationState(
                new ClaimsPrincipal(new ClaimsIdentity())
            );
        }
        return new AuthenticationState(new ClaimsPrincipal(
            new ClaimsIdentity(ParseClaimsFromJwt(jwt), "JwtAuth")
        ));
    }

    private bool isValidateExpiredToken(string jwt)
    {
        var claims = ParseClaimsFromJwt(jwt);
        var exp = claims.Where(key => key.Type == "exp").Select(key => key.Value).First();
        var expirationTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(exp)).UtcDateTime;
        if (expirationTime <= DateTime.UtcNow)
        {
            return true;
        }
        return false;
    }


    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuesPairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuesPairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    }

    private static byte[] ParseBase64WithoutPadding(string payload)
    {
        switch (payload.Length % 4)
        {
            case 2: payload += "=="; break;
            case 3: payload += "="; break;
        }
        return Convert.FromBase64String(payload);
    }

    public void NotifyAuthState()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
