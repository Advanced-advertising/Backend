using ADvanced.Data.Interfaces;
using ADvanced.Models;

namespace ADvanced.Data.Repository;

public class IncomeRepository : IRepository<Income>
{
    private readonly ApplicationContext _context;

    public IncomeRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Income> GetItemList()
    {
        return _context.Incomes.ToList();
    }

    public Income GetItem(int id)
    {
        return _context.Incomes.Where(c => c.Id == id).FirstOrDefault();
    }

    public bool Create(Income income)
    {
        _context.Incomes.Add(income);
        return Save();
    }

    public bool Update(Income income)
    {
        _context.Incomes.Update(income);
        return Save();
    }

    public bool Delete(Income income)
    {
        _context.Incomes.Remove(income);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}