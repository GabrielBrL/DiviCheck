using CTRLInvesting.Client.Interfaces;
using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Client.Services;
public class HomeStocksService : IHomeStocksService
{
    private readonly HttpClient _httpClient;

    public HomeStocksService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<StockDataDetails>> TopGaining(int position)
    {
        await Task.Delay(1);
        return new List<StockDataDetails>();
    }
}