using System.ComponentModel.DataAnnotations;

namespace CTRLInvesting.Model.Usuario;

public class RegisterModel
{
    public string Usuario { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }
    public int IdRole { get; set; } = 1;
}
