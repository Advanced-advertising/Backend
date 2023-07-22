using ADvanced.Data.Interfaces;
using ADvanced.Models;

namespace ADvanced.Data.Repository;

public class AdOrderRepository : IRepository<AdOrder>
{
    private readonly ApplicationContext _context;

    public AdOrderRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public IEnumerable<AdOrder> GetItemList()
    {
        return _context.AdOrders.ToList();
    }

    public AdOrder GetItem(int id)
    {
        return _context.AdOrders.Where(c => c.Id == id).FirstOrDefault();
    }

    public async Task<bool> Create(AdOrder adOrder)
    {
        _context.AdOrders.Add(adOrder);
        return await Save();
    }

    public async Task<bool> Update(AdOrder adOrder)
    {
        _context.AdOrders.Update(adOrder);
        return await Save();
    }

    public async Task<bool> Delete(AdOrder adOrder)
    {
        _context.AdOrders.Remove(adOrder);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }
}