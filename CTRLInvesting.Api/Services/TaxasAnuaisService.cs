using CTRLInvesting.Api.Interfaces;
using Newtonsoft.Json;

namespace CTRLInvesting.Api.Services;

public class TaxasAnuaisService : ITaxasAnuaisService
{
    private readonly HttpClient _httpClient;

    public TaxasAnuaisService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<double> GetSelic()
    {
        string url = "https://flask-production-90940.up.railway.app/gab2020/taxa/432";
        var response = await _httpClient.GetAsync(url);
        var jsonString = await response.Content.ReadAsStringAsync();
        var stockData = JsonConvert.DeserializeObject<double>(jsonString);
        return stockData/100;
    }

    public async Task<double> GetCdi()
    {
        string url = "https://flask-production-90940.up.railway.app/gab2020/taxa/4389";
        var response = await _httpClient.GetAsync(url);
        var jsonString = await response.Content.ReadAsStringAsync();
        var stockData = JsonConvert.DeserializeObject<double>(jsonString);
        return stockData/100;
    }
}
