using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.Interfaces
{
    public interface IAcoesService
    {
        Task<Dictionary<string, double>> GetValueAcaoAsync(string nome);
        Dictionary<string, double> GetValueAcao(string nome);
        Task<StockDataDetails> GetAcaoAsync(string nome);
        StockDataDetails GetAcao(string ticket);
        Task<List<string>> GetAllTicketsAsync();
    }
}