using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Model.Stocks;
using CTRLInvesting.Model.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CTRLInvesting.Api.Controllers;

[Authorize(Policy = "UserDefault")]
[ApiController]
[Route("[controller]")]
public class InvestimentoController : ControllerBase
{
    private readonly IInvestimentosService _investimentosService;

    public InvestimentoController(IInvestimentosService investimentosService)
    {
        _investimentosService = investimentosService;
    }

    // [HttpGet("{idUsuario}")]
    // public List<StockDataDetails> GetStockDataDetails(int idUsuario)
    // {
    //     return _investimentosService.GetStockDataDetails(idUsuario);
    // }

    [HttpGet("{idUsuario}")]
    public async Task<List<StockDataDetails>> GetStockDataDetailsAsync(int idUsuario)
    {
        return await _investimentosService.GetStockDataDetailsAsync(idUsuario);
    }

    [HttpGet("{idUsuario}/top5")]
    public List<string> GetTop5Tickets(int idUsuario)
    {
        return _investimentosService.GetTop5Tickets(idUsuario);
    }

    [HttpPost("insert")]
    public async Task InsertStock([FromBody] FormStocks formStocks)
    {
        await _investimentosService.InsertStockAsync(formStocks.IdUsuario, formStocks.Symbol, formStocks.NumeroAcoes);
    }

    [HttpPost("update")]
    public async Task UpdateStock([FromBody] FormStocks formStocks)
    {
        await _investimentosService.UpdateStock(formStocks.IdUsuario, formStocks.Symbol, formStocks.NumeroAcoes);
    }
    [HttpPost("delete")]
    public async Task DeleteStock([FromBody] FormStocks formStocks)
    {
        await _investimentosService.DeleteStock(formStocks.IdUsuario, formStocks.Symbol);
    }
}
