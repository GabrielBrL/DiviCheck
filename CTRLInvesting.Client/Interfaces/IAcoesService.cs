using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Client.Interfaces;

public interface IAcoesService
{
    Dictionary<string, double> GetValueAcao(string ticket);
    StockDataDetails GetAcao(string ticket);
    Task<List<string>> GetAllTicketsAsync();
    void GetVariationStocks(StockDataDetails acao);
}
