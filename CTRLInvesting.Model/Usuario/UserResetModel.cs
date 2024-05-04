using System.ComponentModel.DataAnnotations;

namespace CTRLInvesting.Model.Usuario;

public class UserResetModel
{    
    public string Hash { get; set; }
    public string NewPassword { get; set; }
}
