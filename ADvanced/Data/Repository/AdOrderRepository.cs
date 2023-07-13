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

    public bool Create(AdOrder adOrder)
    {
        _context.AdOrders.Add(adOrder);
        return Save();
    }

    public bool Update(AdOrder adOrder)
    {
        _context.AdOrders.Update(adOrder);
        return Save();
    }

    public bool Delete(AdOrder adOrder)
    {
        _context.AdOrders.Remove(adOrder);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}