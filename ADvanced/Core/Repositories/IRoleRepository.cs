using Microsoft.AspNetCore.Identity;

namespace ADvanced.Core.Repositories;

public interface IRoleRepository
{
    ICollection<IdentityRole> GetRoles();
}