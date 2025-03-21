using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Client.Interfaces;

public interface IAcoesService
{
    Dictionary<string, double> GetVariacaoAcao(string ticket, string variacao);
    Task<Dictionary<string, double>> GetVariacaoAcaoAsync(string ticket, string variacao);
    StockDataDetails GetAcao(string ticket);
    Task<StockDataDetails> GetAcaoAsync(string ticket);
    Task<List<Stock>> GetAllTicketsAsync();
    Dictionary<string, double> GetHistDividends(string ticket);
}
