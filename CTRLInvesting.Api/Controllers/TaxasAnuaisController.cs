using CTRLInvesting.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CTRLInvesting.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class TaxasAnuaisController
{
    private readonly ITaxasAnuaisService _taxasAnuaisService;

    public TaxasAnuaisController(ITaxasAnuaisService taxasAnuaisService)
    {
        _taxasAnuaisService = taxasAnuaisService;
    }
    [HttpGet("selic")]
    public Task<double> GetSelic()
    {
        return _taxasAnuaisService.GetSelic();
    }
    [HttpGet("cdi")]
    public Task<double> GetCdi()
    {
        return _taxasAnuaisService.GetCdi();
    }
}
