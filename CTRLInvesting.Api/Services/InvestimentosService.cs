using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Api.IRepository;
using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.Services;

public class InvestimentosService : IInvestimentosService
{
    private readonly IAcoesService _acoesService;
    private readonly IInvestidorRepository _investidorRepo;
    public InvestimentosService(IAcoesService acoesService, IInvestidorRepository investidor)
    {
        _acoesService = acoesService;
        _investidorRepo = investidor;
    }

    public List<StockDataDetails> GetStockDataDetails(int idUsuario)
    {
        var investimentos = _investidorRepo.GetInvestidors(idUsuario);
        List<StockDataDetails> stockDataDetails = new List<StockDataDetails>();
        foreach (var investimento in investimentos)
        {
            var stock = _acoesService.GetAcao(investimento.Ticket);
            stock.NumeroAcoes = investimento.QtdStocks;
            stockDataDetails.Add(stock);
        }
        return stockDataDetails;
    }

    public async Task InsertStockAsync(int idUsuario, string symbol, int numeroAcoes)
    {
        await _investidorRepo.InsertStockAsync(idUsuario, symbol, numeroAcoes);
    }

    public async Task UpdateStock(int idUsuario, string symbol, int numeroAcoes)
    {
        await _investidorRepo.UpdateStock(idUsuario, symbol, numeroAcoes);
    }

    public async Task DeleteStock(int idUsuario, string symbol)
    {
        await _investidorRepo.DeleteStock(idUsuario, symbol);
    }
}
