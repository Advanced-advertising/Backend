using ADvanced.Data.Interfaces;
using ADvanced.Models;

namespace ADvanced.Data.Repository;

public class UserRepository : IRepository<User>
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public IEnumerable<User> GetItemList()
    {
        return _context.Users.ToList();
    }

    public User GetItem(int id)
    {
        return _context.Users.Where(c => c.Id == id).FirstOrDefault();
    }

    public bool Create(User user)
    {
        _context.Users.Add(user);
        return Save();
    }

    public bool Update(User user)
    {
        _context.Users.Update(user);
        return Save();
    }

    public bool Delete(User user)
    {
        _context.Users.Remove(user);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}