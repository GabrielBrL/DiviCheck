using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using CTRLInvesting.Api.Data;
using CTRLInvesting.Api.IRepository;
using CTRLInvesting.Model.Stocks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CTRLInvesting.Api.Repository;

public class AcoesRepository : IAcoesRepository
{

    public AcoesRepository()
    {
    }
    public async Task<Dictionary<string, double>> GetValueAcoesAsync(string ticket)
    {
        using (HttpClient _httpClient = new HttpClient())
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/{ticket}";
            var response = await _httpClient.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();
            Dictionary<string, double> stockData = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonString);
            return stockData;
        }
    }

    public Dictionary<string, double> GetValueAcoes(string ticket)
    {
        using (HttpClient _httpClient = new HttpClient())
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/{ticket}";
            var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Dictionary<string, double> stockData = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonString);
            return stockData;
        }
    }

    public async Task<StockDataDetails> GetAcaoAsync(string ticket)
    {
        using (HttpClient _httpClient = new HttpClient())
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/papel/{ticket}";
            var response = await _httpClient.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();
            StockDataDetails stockData = JsonConvert.DeserializeObject<StockDataDetails>(jsonString);
            return stockData;
        }
    }

    public StockDataDetails GetAcao(string ticket)
    {
        using (HttpClient _httpClient = new HttpClient())
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/papel/{ticket}";
            var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            StockDataDetails stockData = JsonConvert.DeserializeObject<StockDataDetails>(jsonString);
            return stockData;
        }
    }

    public async Task<List<string>> GetAllTickets()
    {
        using (HttpClient _httpClient = new HttpClient())
        {
            string url = $"https://flask-production-90940.up.railway.app/gab2020/papeis";
            var response = await _httpClient.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();
            List<string> tickets = JsonConvert.DeserializeObject<List<string>>(jsonString);
            return tickets;
        }
    }
}
