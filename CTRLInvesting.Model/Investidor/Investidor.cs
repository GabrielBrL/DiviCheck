using Usuarios = CTRLInvesting.Model.Usuario;
using Stocks = CTRLInvesting.Model.Stocks;
using System.ComponentModel.DataAnnotations;
namespace CTRLInvesting.Model.Investidor;

public class Investidor
{
    [Key]
    public int IdInvestidor { get; set; }
    public int IdUsuario { get; set; }
    public string? Ticket { get; set; }
    public int QtdStocks { get; set; }

    public List<Usuarios.Usuario>? Usuario { get; set; }
}
