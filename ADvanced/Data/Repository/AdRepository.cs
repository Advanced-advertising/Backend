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

    public bool Create(Ad ad)
    {
        _context.Ads.Add(ad);
        return Save();
    }

    public bool Update(Ad ad)
    {
        _context.Ads.Update(ad);
        return Save();
    }

    public bool Delete(Ad ad)
    {
        _context.Ads.Remove(ad);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}