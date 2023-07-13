using ADvanced.Data.Interfaces;
using ADvanced.Models;

namespace ADvanced.Data.Repository;

public class ScreenRepository : IRepository<Screen>
{
    private readonly ApplicationContext _context;

    public ScreenRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Screen> GetItemList()
    {
        return _context.Screens.ToList();
    }

    public Screen GetItem(int id)
    {
        return _context.Screens.Where(c => c.Id == id).FirstOrDefault();
    }

    public bool Create(Screen screen)
    {
        _context.Screens.Add(screen);
        return Save();
    }

    public bool Update(Screen screen)
    {
        _context.Screens.Update(screen);
        return Save();
    }

    public bool Delete(Screen screen)
    {
        _context.Screens.Remove(screen);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}