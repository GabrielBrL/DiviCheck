using CTRLInvesting.Model;
using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.Interfaces
{
    public interface IAcoesService
    {
        Task<Dictionary<string, double>> GetVariacaoAcoesAsync(string ticket, string variacao);
        Dictionary<DateTime, double> GetVariacaoAcoes(string ticket, string variacao);
        Dictionary<DateTime, double> GetHistDividendos(string ticket);
        Task<StockDataDetails> GetAcaoAsync(string ticket);
        StockDataDetails GetAcao(string ticket);
        Task<List<string>> GetAllTickets();
        List<Stock> GetAllTicketsFromDb();
        Task<string> AddTicketStocks();
    }
}