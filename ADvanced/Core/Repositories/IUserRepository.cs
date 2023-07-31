using ADvanced.Areas.Identity.Data;

namespace ADvanced.Core.Repositories;

public interface IUserRepository
{
    ICollection<ApplicationUser> GetUsers();

    ApplicationUser GetUser(string id);

    ApplicationUser UpdateUser(ApplicationUser user);
}