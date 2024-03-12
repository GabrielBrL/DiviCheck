using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Client.Interfaces;

public interface IAcoesService
{
    Dictionary<string, double> GetVariacaoAcao(string ticket, string variacao);
    Task<Dictionary<string, double>> GetVariacaoAcaoAsync(string ticket, string variacao);
    StockDataDetails GetAcao(string ticket);
    Task<List<Stock>> GetAllTicketsAsync();
}
