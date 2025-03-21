using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.Interfaces;

public interface IInvestimentosService
{
    List<StockDataDetails> GetStockDataDetails(int idUsuario);
    Task<List<StockDataDetails>> GetStockDataDetailsAsync(int idUsuario);
    List<string> GetTop5Tickets(int idUsuario);
    Task InsertStockAsync(int idUsuario, string symbol, int numeroAcoes);
    Task UpdateStock(int idUsuario, string symbol, int numeroAcoes);
    Task DeleteStock(int idUsuario, string symbol);
}
