using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Client.Interfaces;
public interface IHomeStocksService
{
    Task<List<StockDataDetails>> TopGaining(int position);
}