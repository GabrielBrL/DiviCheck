using CTRLInvesting.Api.Data;
using CTRLInvesting.Api.IRepository;
using CTRLInvesting.Model.Investidor;

namespace CTRLInvesting.Api.Repository;

public class InvestidorRepository : IInvestidorRepository
{
    private readonly DataContext _context;

    public InvestidorRepository(DataContext context)
    {
        _context = context;
    }

    public List<Investidor> GetInvestidors(int idUsuario)
    {
        return _context.Investidor.Where(x => x.IdUsuario == idUsuario).ToList();
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
