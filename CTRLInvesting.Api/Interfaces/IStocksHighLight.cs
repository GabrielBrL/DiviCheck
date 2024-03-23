using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.Interfaces;

public interface IStocksHighLight
{
    Task<List<StockDataDetails>> GetGaining(int ticket);
}
