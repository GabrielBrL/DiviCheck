using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Api.IRepository;
using CTRLInvesting.Model;
using CTRLInvesting.Model.Stocks;
using Newtonsoft.Json;

namespace CTRLInvesting.Api.Services
{
    public class AcoesService : IAcoesService
    {
        private readonly HttpClient _httpClient;
        private readonly IStockRepository _stockRepository;

        public AcoesService(HttpClient httpClient, IStockRepository stockRepository)
        {
            _httpClient = httpClient;
            _stockRepository = stockRepository;
        }
        public async Task<Dictionary<string, double>> GetVariacaoAcoesAsync(string ticket, string variacao)
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/{ticket}/{variacao}";
            var response = await _httpClient.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();
            Dictionary<string, double> stockData = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonString);
            return stockData;
        }

        public Dictionary<DateTime, double> GetVariacaoAcoes(string ticket, string variacao)
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/{ticket}/{variacao}";
            var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Dictionary<DateTime, double> stockData = JsonConvert.DeserializeObject<Dictionary<DateTime, double>>(jsonString);
            return stockData;
        }

        public async Task<StockDataDetails> GetAcaoAsync(string ticket)
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/papel/{ticket}";
            var response = await _httpClient.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();
            StockDataDetails stockData = JsonConvert.DeserializeObject<StockDataDetails>(jsonString);
            return stockData;
        }

        public StockDataDetails GetAcao(string ticket)
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/papel/{ticket}";
            var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            StockDataDetails stock = JsonConvert.DeserializeObject<StockDataDetails>(jsonString);            
            var dividends = GetHistDividendos(ticket);
            double LastDividendValue = dividends.Last().Value;            
            stock.LastDividendValue = LastDividendValue;
            string date = dividends.Last().Key.ToString("dd/MM/yyyy");
            stock.LastDividendDate = DateTime.Parse(date).Ticks / 10000000 - 62135596800;
            return stock;
        }

        public async Task<List<string>> GetAllTickets()
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/papeis";
            var response = await _httpClient.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();
            List<string> tickets = JsonConvert.DeserializeObject<List<string>>(jsonString);
            return tickets;
        }

        public Dictionary<DateTime, double> GetHistDividendos(string ticket)
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/dividends/{ticket}";
            var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Dictionary<DateTime, double> stockData = JsonConvert.DeserializeObject<Dictionary<DateTime, double>>(jsonString);
            return stockData;
        }

        public List<Stock> GetAllTicketsFromDb()
        {
            return _stockRepository.GetAllTickets();
        }

        public async Task<string> AddTicketStocks()
        {
            List<string> tickets = await GetAllTickets();
            foreach (var ticket in tickets)
            {
                try
                {
                    var stockDetail = GetAcao(ticket);
                    await _stockRepository.AddOrUpdateStock(ticket, stockDetail);
                }
                catch (Exception e)
                {
                    Console.WriteLine(ticket);
                }
            }
            return "Atualizado";
        }
    }
}