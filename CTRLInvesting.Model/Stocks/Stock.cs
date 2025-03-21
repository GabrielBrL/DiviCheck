using System.ComponentModel.DataAnnotations;

namespace CTRLInvesting.Model.Stocks;

public class Stock
{
    [Key]
    public string Symbol { get; set; }
    public string LongName { get; set; }
    public string? Imagem { get; set; }
}
