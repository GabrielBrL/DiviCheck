using CTRLInvesting.Api.Data;
using CTRLInvesting.Model.Roles;

namespace CTRLInvesting.Api.Repository;

public class RolesRepository
{
    private readonly DataContext _context;

    public RolesRepository(DataContext context)
    {
        _context = context;
    }
    public string GetRole(int id)
    {
        return _context.Roles.SingleOrDefault(x => x.IdRole == id).Role;
    }
    public List<Roles> GetRoles()
    {
        return _context.Roles.ToList();
    }
}
