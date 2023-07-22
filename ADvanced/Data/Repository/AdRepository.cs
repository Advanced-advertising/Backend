using ADvanced.Data.Interfaces;
using ADvanced.Models;

namespace ADvanced.Data.Repository;

public class AdRepository : IRepository<Ad>
{
    private readonly ApplicationContext _context;

    public AdRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Ad> GetItemList()
    {
        return _context.Ads.ToList();
    }

    public Ad GetItem(int id)
    {
        return _context.Ads.Where(c => c.Id == id).FirstOrDefault();
    }

    public async Task<bool> Create(Ad ad)
    {
        _context.Ads.Add(ad);
        return await Save();
    }

    public async Task<bool> Update(Ad ad)
    {
        _context.Ads.Update(ad);
        return await Save();
    }

    public async Task<bool> Delete(Ad ad)
    {
        _context.Ads.Remove(ad);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }
}