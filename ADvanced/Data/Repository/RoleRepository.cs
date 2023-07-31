using ADvanced.Areas.Identity.Data;
using ADvanced.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace ADvanced.Data.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationIdentityContext _context;

    public RoleRepository(ApplicationIdentityContext context)
    {
        _context = context;
    }

    public ICollection<IdentityRole> GetRoles()
    {
        return _context.Roles.ToList();
    }
}