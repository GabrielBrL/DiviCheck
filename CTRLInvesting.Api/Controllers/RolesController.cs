using CTRLInvesting.Api.Repository;
using CTRLInvesting.Model.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CTRLInvesting.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class RolesController : ControllerBase
{
    private readonly RolesRepository _reposity;

    public RolesController(RolesRepository reposity)
    {
        _reposity = reposity;
    }
    [HttpGet()]
    public List<Roles> GetRoles()
    {
        return _reposity.GetRoles();
    }
    [HttpGet("{id}")]
    public string GetRole(int id)
    {
        return _reposity.GetRole(id);
    }
}
