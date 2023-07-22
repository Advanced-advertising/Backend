using ADvanced.Data.Interfaces;
using ADvanced.Models;

namespace ADvanced.Data.Repository;

public class BusinessRepository : IRepository<Business>
{
    private readonly ApplicationContext _context;

    public BusinessRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Business> GetItemList()
    {
        return _context.Business.ToList();
    }

    public Business GetItem(int id)
    {
        return _context.Business.Where(c => c.Id == id).FirstOrDefault();
    }

    public async Task<bool> Create(Business business)
    {
        _context.Business.Add(business);
        return await Save();
    }

    public async Task<bool> Update(Business business)
    {
        _context.Business.Update(business);
        return await Save();
    }

    public async Task<bool> Delete(Business business)
    {
        _context.Business.Remove(business);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }
}