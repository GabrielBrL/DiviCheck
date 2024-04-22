using CTRLInvesting.Client.Interfaces;

namespace CTRLInvesting.Client.Services;

public class TaxasService : ITaxasService
{
    private readonly HttpClient _httpClient;

    public TaxasService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<double> GetSelicAsync()
    {
        return await _httpClient.GetFromJsonAsync<double>("TaxasAnuais/selic");
    }
    public async Task<double> GetCdiAsync()
    {
        return await _httpClient.GetFromJsonAsync<double>("TaxasAnuais/cdi");
    }

    public double GetSelic()
    {
        return _httpClient.GetFromJsonAsync<double>("TaxasAnuais/selic").GetAwaiter().GetResult();
    }
    public double GetCdi()
    {
        return _httpClient.GetFromJsonAsync<double>("TaxasAnuais/cdi").GetAwaiter().GetResult();
    }
}
