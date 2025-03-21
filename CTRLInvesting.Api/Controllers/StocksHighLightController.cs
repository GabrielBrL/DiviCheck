using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Model.Stocks;
using Microsoft.AspNetCore.Mvc;

namespace CTRLInvesting.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StocksHighLightController : ControllerBase
{
    private readonly IStocksHighLight _stocks;

    public StocksHighLightController(IStocksHighLight stocks)
    {
        _stocks = stocks;
    }

    [HttpGet("topGaining/{position}")]
    public async Task<List<StockDataDetails>> GetNoticias(int position)
    {
        return await _stocks.GetGaining(position);
    }
}
