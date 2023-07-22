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

    public async Task<bool> Create(User user)
    {
        _context.Users.Add(user);
        return await Save();
    }

    public async Task<bool> Update(User user)
    {
        _context.Users.Update(user);
        return await Save();
    }

    public async Task<bool> Delete(User user)
    {
        _context.Users.Remove(user);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }
}