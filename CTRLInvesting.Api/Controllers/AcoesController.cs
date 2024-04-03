using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using CTRLInvesting.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CTRLInvesting.Model.Stocks;
using CTRLInvesting.Model;

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
        [HttpGet("{ticket}/{variacao}")]
        public Dictionary<DateTime, double> GetVariacaoAcao(string ticket, string variacao)
        {
            return _acoesService.GetVariacaoAcoes(ticket, variacao);
        }
        [HttpGet("dividendos/{ticket}")]
        public Dictionary<DateTime, double> GetHistDividendos(string ticket)
        {
            return _acoesService.GetHistDividendos(ticket);
        }
        [HttpGet("papeis")]
        public List<Stock> GetTickets()
        {
            return _acoesService.GetAllTicketsFromDb();
        }
        // [Authorize(Policy = "Manager")]
        [HttpGet("papeis/add")]
        public Task<string> AddTickets()
        {
            return _acoesService.AddTicketStocks();
        }
    }
}