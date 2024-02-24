using System.Text;
using CTRLInvesting.Client.Interfaces;
using CTRLInvesting.Model.Usuario;
using Newtonsoft.Json;

namespace CTRLInvesting.Client.Services;

public class UsuarioService : IUsuarioService
{
    private readonly HttpClient _httpClient;

    public UsuarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> GetUserByEmailAsync(string email)
    {
        return await _httpClient.GetFromJsonAsync<bool>($"/Usuario/email={email}");
    }

    public async Task<bool> GetUserByUsuarioAsync(string usuario)
    {
        return await _httpClient.GetFromJsonAsync<bool>($"/Usuario/usuario={usuario}");
    }

    public async Task<string> Login(LoginModel model)
    {
        var user = JsonConvert.SerializeObject(model);
        var content = new StringContent(user, Encoding.UTF8, "application/json");
        var result = await _httpClient.PostAsync("/Usuario/login", content);
        if (result.IsSuccessStatusCode)
            return await result.Content.ReadAsStringAsync();
        else
        {
            return "Usuário ou senha incorretos";
        }
    }

    public async Task<string> Register(RegisterModel model)
    {
        var user = JsonConvert.SerializeObject(model);
        var content = new StringContent(user, Encoding.UTF8, "application/json");
        var result = await _httpClient.PostAsync("/Usuario/cadastro", content);
        if (result.IsSuccessStatusCode)
        {
            return await result.Content.ReadAsStringAsync();
        }
        return "Erro";
    }

}
