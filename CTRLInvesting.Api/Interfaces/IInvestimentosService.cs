using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.Interfaces;

public interface IInvestimentosService
{
    List<StockDataDetails> GetStockDataDetails(int idUsuario);
    Task InsertStockAsync(int idUsuario, string symbol, int numeroAcoes);
    Task UpdateStock(int idUsuario, string symbol, int numeroAcoes);
    Task DeleteStock(int idUsuario, string symbol);
}
