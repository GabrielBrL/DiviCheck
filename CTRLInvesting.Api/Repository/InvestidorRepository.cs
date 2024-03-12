using CTRLInvesting.Api.Data;
using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Api.IRepository;
using CTRLInvesting.Model.Investidor;
using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.Repository;

public class InvestidorRepository : IInvestidorRepository
{
    private readonly DataContext _context;
    private readonly IAcoesService _acoesService;

    public InvestidorRepository(DataContext context, IAcoesService acoesService)
    {
        _context = context;
        _acoesService = acoesService;
    }

    public List<Investidor> GetInvestidors(int idUsuario)
    {
        return _context.Investidor.Where(x => x.IdUsuario == idUsuario).ToList();
    }

    public List<string> GetTop5Tickets(int idUsuario)
    {
        List<KeyValuePair<string,double>> listStockDataDetails = new List<KeyValuePair<string,double>>();
        var stocks = _context.Investidor.Where(x => x.IdUsuario == idUsuario);
        foreach (var stock in stocks)
        {
            var item = _acoesService.GetAcao(stock.Ticket);
            var vlrTotal = item.CurrentPrice * stock.QtdStocks;
            listStockDataDetails.Add(new KeyValuePair<string, double>(stock.Ticket, vlrTotal.Value));
        }
        return listStockDataDetails.OrderByDescending(x => x.Value).Take(5).Select(x => x.Key).ToList();
    }

    public async Task InsertStockAsync(int idUsuario, string symbol, int numeroAcoes)
    {
        var existInvestimento = GetInvestidors(idUsuario).FirstOrDefault(x => x.Ticket == symbol);
        if (existInvestimento != null)
        {
            existInvestimento.QtdStocks += numeroAcoes;
            _context.Investidor.Update(existInvestimento);
            await _context.SaveChangesAsync();
            return;
        }
        Investidor investidor = new Investidor
        {
            IdUsuario = idUsuario,
            Ticket = symbol,
            QtdStocks = numeroAcoes
        };
        await _context.Investidor.AddAsync(investidor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStock(int idUsuario, string symbol, int numeroAcoes)
    {
        var userStock = GetInvestidors(idUsuario).FirstOrDefault(x => x.Ticket == symbol);
        userStock.QtdStocks = numeroAcoes;
        _context.Investidor.Update(userStock);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStock(int idUsuario, string symbol)
    {
        var userStock = GetInvestidors(idUsuario).FirstOrDefault(x => x.Ticket == symbol);
        _context.Investidor.Remove(userStock);
        await _context.SaveChangesAsync();
    }
}
