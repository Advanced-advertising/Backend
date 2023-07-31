using ADvanced.Areas.Identity.Data;
using ADvanced.Core.Repositories;

namespace ADvanced.Data.Repository;

public class UserIdenityRepository : IUserRepository
{
    private readonly ApplicationIdentityContext _context;

    public UserIdenityRepository(ApplicationIdentityContext context)
    {
        _context = context;
    }

    public ICollection<ApplicationUser> GetUsers()
    {
        return _context.Users.ToList();
    }

    public ApplicationUser GetUser(string id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public ApplicationUser UpdateUser(ApplicationUser user)
    {
        _context.Update(user);
        _context.SaveChanges();

        return user;
    }
}