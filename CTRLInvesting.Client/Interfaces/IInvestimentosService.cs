using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Client.Interfaces;

public interface IInvestimentosService
{
    Task<List<StockDataDetails>> GetStockDataDetails(int idUsuario);
    Task<List<string>> GetTop5Tickets(int idUsuario);
    bool FileExist(string path);
    Task InsertStockDataDetails(FormStocks formStocks);
    Task UpdateStockDataDetails(FormStocks formStocks);
    Task DeleteStockDataDetails(FormStocks formStocks);
}
