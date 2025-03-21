using System.Net.Http.Headers;
using System.Text;
using CTRLInvesting.Client.Interfaces;
using CTRLInvesting.Model.Stocks;
using Newtonsoft.Json;
using Blazored.LocalStorage;

namespace CTRLInvesting.Client.Services;

public class InvestimentosService : IInvestimentosService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;
    private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
    public InvestimentosService(HttpClient httpClient, ILocalStorageService localStorageService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
        _hostingEnvironment = hostingEnvironment;
    }
    public async Task<List<StockDataDetails>> GetStockDataDetails(int idUsuario)
    {
        var savedToken = await _localStorageService.GetItemAsync<string>("token");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
        return await _httpClient.GetFromJsonAsync<List<StockDataDetails>>($"/Investimento/{idUsuario}");
    }
    public async Task<List<string>> GetTop5Tickets(int idUsuario)
    {
        var savedToken = await _localStorageService.GetItemAsync<string>("token");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
        return await _httpClient.GetFromJsonAsync<List<string>>($"/Investimento/{idUsuario}/top5");
    }
    public bool FileExist(string ticket)
    {
        string[] filePaths = Directory.GetFiles(Path.Combine(_hostingEnvironment.WebRootPath, "assets/"));
        return filePaths.Where(x => x.EndsWith($"{ticket.Substring(0,4)}.svg")).Count() > 0;
    }
    public async Task InsertStockDataDetails(FormStocks formStocks)
    {
        var user = JsonConvert.SerializeObject(formStocks);
        var content = new StringContent(user, Encoding.UTF8, "application/json");
        var savedToken = await _localStorageService.GetItemAsync<string>("token");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
        await _httpClient.PostAsync("/Investimento/insert", content);
    }
    public async Task UpdateStockDataDetails(FormStocks formStocks)
    {
        var user = JsonConvert.SerializeObject(formStocks);
        var content = new StringContent(user, Encoding.UTF8, "application/json");
        var savedToken = await _localStorageService.GetItemAsync<string>("token");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
        await _httpClient.PostAsync("/Investimento/update", content);
    }
    public async Task DeleteStockDataDetails(FormStocks formStocks)
    {
        var user = JsonConvert.SerializeObject(formStocks);
        var content = new StringContent(user, Encoding.UTF8, "application/json");
        var savedToken = await _localStorageService.GetItemAsync<string>("token");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
        await _httpClient.PostAsync("/Investimento/delete", content);
    }
}
