using System.ComponentModel.DataAnnotations;

namespace CTRLInvesting.Model.Roles;

public class Roles
{
    [Key]
    public int IdRole { get; set; }
    public string Role { get; set; }
    public ICollection<Usuario.Usuario> Usuarios { get; set; }
}
