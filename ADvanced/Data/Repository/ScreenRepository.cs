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

    public async Task<bool> Create(Screen screen)
    {
        _context.Screens.Add(screen);
        return await Save();
    }

    public async Task<bool> Update(Screen screen)
    {
        _context.Screens.Update(screen);
        return await Save();
    }

    public async Task<bool> Delete(Screen screen)
    {
        _context.Screens.Remove(screen);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }
}