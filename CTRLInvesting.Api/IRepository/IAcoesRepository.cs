using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.IRepository;

public interface IAcoesRepository
{
    Task<Dictionary<string, double>> GetValueAcoesAsync(string ticket);
    Dictionary<string, double> GetValueAcoes(string ticket);
    Task<StockDataDetails> GetAcaoAsync(string ticket);
    StockDataDetails GetAcao(string ticket);
    Task<List<string>> GetAllTickets();
}
