using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Api.IRepository;
using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.Services
{
    public class AcoesService : IAcoesService
    {
        private readonly IAcoesRepository _acoesRepository;
        public AcoesService(IAcoesRepository acoesRepository)
        {
            _acoesRepository = acoesRepository;
        }
        public async Task<StockDataDetails> GetAcaoAsync(string ticket)
        {
            return await _acoesRepository.GetAcaoAsync(ticket);
        }
        public async Task<Dictionary<string, double>> GetValueAcaoAsync(string ticket)
        {
            return await _acoesRepository.GetValueAcoesAsync(ticket);
        }
        public async Task<List<string>> GetAllTicketsAsync()
        {
            return await _acoesRepository.GetAllTickets();
        }
        public StockDataDetails GetAcao(string ticket)
        {
            return _acoesRepository.GetAcao(ticket);
        }
        public Dictionary<string, double> GetValueAcao(string nome)
        {
            return _acoesRepository.GetValueAcoes(nome);
        }
    }
}