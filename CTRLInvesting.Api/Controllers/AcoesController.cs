using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using CTRLInvesting.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CTRLInvesting.Model.Stocks;

namespace CTRLInvesting.Api.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class AcoesController : ControllerBase
    {
        private readonly IAcoesService _acoesService;

        public AcoesController(IAcoesService acoesService)
        {
            _acoesService = acoesService;
        }        
        [HttpGet("papel/{ticket}")]
        public StockDataDetails GetAcao(string ticket)
        {
            return _acoesService.GetAcao(ticket);
        }        
        [HttpGet("{ticket}")]
        public Dictionary<string, double> GetValueAcao(string ticket)
        {
            return _acoesService.GetValueAcao(ticket);
        }
        [HttpGet("papeis")]
        public Task<List<string>> GetTickets()
        {
            return _acoesService.GetAllTicketsAsync();
        }
    }
}