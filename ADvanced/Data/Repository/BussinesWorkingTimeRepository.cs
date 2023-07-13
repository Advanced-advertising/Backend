using ADvanced.Data.Interfaces;
using ADvanced.Models;

namespace ADvanced.Data.Repository;

public class BussinesWorkingTimeRepository : IRepository<BusinessWorkingTime>
{
    private readonly ApplicationContext _context;

    public BussinesWorkingTimeRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public IEnumerable<BusinessWorkingTime> GetItemList()
    {
        return _context.BusinessWorkingTimes.ToList();
    }

    public BusinessWorkingTime GetItem(int id)
    {
        return _context.BusinessWorkingTimes.Where(c => c.Id == id).FirstOrDefault();
    }

    public bool Create(BusinessWorkingTime businessWorkingTime)
    {
        _context.BusinessWorkingTimes.Add(businessWorkingTime);
        return Save();
    }

    public bool Update(BusinessWorkingTime businessWorkingTime)
    {
        _context.BusinessWorkingTimes.Update(businessWorkingTime);
        return Save();
    }

    public bool Delete(BusinessWorkingTime businessWorkingTime)
    {
        _context.BusinessWorkingTimes.Remove(businessWorkingTime);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}