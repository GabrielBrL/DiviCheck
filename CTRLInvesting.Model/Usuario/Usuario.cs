using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Investidores = CTRLInvesting.Model.Investidor;

namespace CTRLInvesting.Model.Usuario;

public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }
    [ForeignKey("FK_Role")]
    public int IdRole { get; set; }
    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }
    [Required]
    [MaxLength(20)]
    public string Password { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    public string JwtToken { get; set; }
    public string Salt { get; set; }
    public List<Investidores.Investidor> Investidors { get; set; }
    public Roles.Roles Role { get; set; }
}
