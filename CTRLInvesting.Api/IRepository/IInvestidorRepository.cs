using CTRLInvesting.Model.Investidor;

namespace CTRLInvesting.Api.IRepository;

public interface IInvestidorRepository
{
    List<Investidor> GetInvestidors(int idUsuario);
    Task InsertStockAsync(int idUsuario, string symbol, int numeroAcoes);
    Task UpdateStock(int idUsuario, string symbol, int numeroAcoes);
    Task DeleteStock(int idUsuario, string symbol);
    List<string> GetTop5Tickets(int idUsuario);
}
