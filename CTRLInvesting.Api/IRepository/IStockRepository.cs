using CTRLInvesting.Model;
using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.IRepository;

public interface IStockRepository
{
    List<Stock> GetAllTickets();
    Task AddOrUpdateStock(string tickets, StockDataDetails stockDataDetails);
}
