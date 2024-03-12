using CTRLInvesting.Client.Interfaces;
using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Client.Services;

public class AcoesService : IAcoesService
{
    private readonly HttpClient _httpClient;

    public AcoesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // public async Task<StockDataDetails> GetAcaoAsync(string ticket)
    // {
    //     return await _httpClient.GetFromJsonAsync<StockDataDetails>($"/Acoes/papel/{ticket}");
    // }

    public StockDataDetails GetAcao(string ticket)
    {
        return _httpClient.GetFromJsonAsync<StockDataDetails>($"/Acoes/papel/{ticket}").GetAwaiter().GetResult();
    }

    public Dictionary<string, double> GetVariacaoAcao(string ticket, string variacao)
    {
        return _httpClient.GetFromJsonAsync<Dictionary<string, double>>($"/Acoes/{ticket}/{variacao}").GetAwaiter().GetResult();
    }

    public async Task<Dictionary<string, double>> GetVariacaoAcaoAsync(string ticket, string variacao)
    {
        return await _httpClient.GetFromJsonAsync<Dictionary<string, double>>($"/Acoes/{ticket}/{variacao}");
    }

    public async Task<List<Stock>> GetAllTicketsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Stock>>("/Acoes/papeis");
    }
}
