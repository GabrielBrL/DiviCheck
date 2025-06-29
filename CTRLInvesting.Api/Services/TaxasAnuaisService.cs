using CTRLInvesting.Api.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

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
        double stockData = await GetTaxaSelic();
        return stockData / 100;
    }

    async Task<double> GetTaxaSelic()
    {
        // URL para o último valor da SELIC diária
        string url = "https://api.bcb.gov.br/dados/serie/bcdata.sgs.432/dados/ultimos/1?formato=json";

        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var tax = JsonConvert.DeserializeObject<List<BcbSgsResponse>>(json)[0];

        if (double.TryParse(tax.valor, new CultureInfo("en-US"), out double value))
            return value;
        return 0;
    }

    public async Task<double> GetCdi()
    {
        string url = "https://flask-production-90940.up.railway.app/gab2020/taxa/4389";
        var response = await _httpClient.GetAsync(url);
        var jsonString = await response.Content.ReadAsStringAsync();
        var stockData = JsonConvert.DeserializeObject<double>(jsonString);
        return stockData / 100;
    }

    class BcbSgsResponse
    {
        public string data { get; set; }
        public string valor { get; set; }
    }
}
