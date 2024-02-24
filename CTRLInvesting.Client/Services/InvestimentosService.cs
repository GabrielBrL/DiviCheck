using System.Text;
using CTRLInvesting.Client.Interfaces;
using CTRLInvesting.Model.Stocks;
using Newtonsoft.Json;

namespace CTRLInvesting.Client.Services;

public class InvestimentosService : IInvestimentosService
{
    private readonly HttpClient _httpClient;
    public InvestimentosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public List<StockDataDetails> GetStockDataDetails(int idUsuario)
    {
        return _httpClient.GetFromJsonAsync<List<StockDataDetails>>($"/Investimento/{idUsuario}").GetAwaiter().GetResult();
    }
    public async Task InsertStockDataDetails(FormStocks formStocks)
    {
        var user = JsonConvert.SerializeObject(formStocks);
        var content = new StringContent(user, Encoding.UTF8, "application/json");
        await _httpClient.PostAsync("/Investimento/insert", content);
    }
    public async Task UpdateStockDataDetails(FormStocks formStocks)
    {
        var user = JsonConvert.SerializeObject(formStocks);
        var content = new StringContent(user, Encoding.UTF8, "application/json");
        await _httpClient.PostAsync("/Investimento/update", content);
    }
    public async Task DeleteStockDataDetails(FormStocks formStocks)
    {
        var user = JsonConvert.SerializeObject(formStocks);
        var content = new StringContent(user, Encoding.UTF8, "application/json");
        await _httpClient.PostAsync("/Investimento/delete", content);
    }
}
