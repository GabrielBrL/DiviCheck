using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Client.Interfaces;

public interface IInvestimentosService
{
    List<StockDataDetails> GetStockDataDetails(int idUsuario);
    Task InsertStockDataDetails(FormStocks formStocks);
    Task UpdateStockDataDetails(FormStocks formStocks);
    Task DeleteStockDataDetails(FormStocks formStocks);
}
