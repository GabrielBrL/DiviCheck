using CTRLInvesting.Api.Data;
using CTRLInvesting.Api.Interfaces;
using CTRLInvesting.Api.IRepository;
using CTRLInvesting.Model;
using CTRLInvesting.Model.Stocks;
using Microsoft.EntityFrameworkCore;

namespace CTRLInvesting.Api.Repository;

public class StockRepository : IStockRepository
{
    private readonly DataContext context;

    public StockRepository(DataContext context)
    {
        this.context = context;
    }
    public List<Stock> GetAllTickets()
    {
        return context.Stock.ToList();
    }
    public async Task AddOrUpdateStock(string ticket, StockDataDetails stockDataDetails)
    {
        if (await context.Stock.FirstOrDefaultAsync(x => x.Symbol == ticket) == null)
        {
            Stock stock = new Stock { Symbol = ticket };
            context.Stock.Add(stock);
            await context.SaveChangesAsync();
        }
        else if ((await context.Stock.FirstOrDefaultAsync(x => x.Symbol == ticket)).LongName == null)
        {
            Stock stock = new Stock { Symbol = ticket, LongName = stockDataDetails.LongName };
            context.Stock.Update(stock);
            await context.SaveChangesAsync();
        }
    }

}
