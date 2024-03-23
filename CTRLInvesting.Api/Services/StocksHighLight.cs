using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Api.IRepository;
using CTRLInvesting.Model.Stocks;
using Newtonsoft.Json;

namespace CTRLInvesting.Api.Services;

public class StocksHighLight : IStocksHighLight
{
    private readonly HttpClient _httpClient;

    public StocksHighLight(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<StockDataDetails>> GetGaining(int ticket)
    {
        await Task.Delay(1);
        return new List<StockDataDetails>();
    }
}
