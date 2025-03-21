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
            string ticket = stock.Symbol.Substring(0, stock.Symbol.IndexOf('.'));
            var dividends = _acoesService.GetHistDividendos(ticket);
            double LastDividendValue = dividends.Last().Value;            
            stock.LastDividendValue = LastDividendValue;
            string date = dividends.Last().Key.ToString("dd/MM/yyyy");
            stock.LastDividendDate = DateTime.Parse(date).Ticks / 10000000 - 62135596800;
            stock.NumeroAcoes = investimento.QtdStocks;
            stockDataDetails.Add(stock);
        }
        return stockDataDetails;
    }

    public async Task<List<StockDataDetails>> GetStockDataDetailsAsync(int idUsuario)
    {
        var investimentos = _investidorRepo.GetInvestidors(idUsuario);
        List<StockDataDetails> stockDataDetails = new List<StockDataDetails>();
        foreach (var investimento in investimentos)
        {
            var stock = await _acoesService.GetAcaoAsync(investimento.Ticket);
            string ticket = stock.Symbol.Substring(0, stock.Symbol.IndexOf('.'));
            var dividends = _acoesService.GetHistDividendos(ticket);
            double LastDividendValue = dividends.Last().Value;            
            stock.LastDividendValue = LastDividendValue;
            string date = dividends.Last().Key.ToString("dd/MM/yyyy");
            stock.LastDividendDate = DateTime.Parse(date).Ticks / 10000000 - 62135596800;
            stock.NumeroAcoes = investimento.QtdStocks;
            stockDataDetails.Add(stock);
        }
        return stockDataDetails;
    }

    public List<string> GetTop5Tickets(int idUsuario)
    {
        return _investidorRepo.GetTop5Tickets(idUsuario);
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
