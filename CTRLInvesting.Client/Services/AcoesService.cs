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

    public Dictionary<string, double> GetValueAcao(string ticket)
    {
        return _httpClient.GetFromJsonAsync<Dictionary<string, double>>($"/Acoes/{ticket}").GetAwaiter().GetResult();
    }

    public async Task<List<string>> GetAllTicketsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<string>>("/Acoes/papeis");
    }

    public void GetVariationStocks(StockDataDetails acao)
    {
        var variacao = GetValueAcao(acao.Symbol.Substring(0,acao.Symbol.IndexOf('.'))).TakeLast(2);
        var ultData = Convert.ToDateTime(variacao.Last().Key);
        double vlrFinal = variacao.Last().Value;
        double vlrInicial = variacao.First().Value;
        double variacaoValue = vlrFinal - vlrInicial;
        double variacaoPercentual = (variacaoValue / vlrInicial);
        acao.VariacaoPercentual = variacaoPercentual;
        acao.VariacaoValue = variacaoValue;
        acao.DataUltCotacao = ultData;
    }
}
