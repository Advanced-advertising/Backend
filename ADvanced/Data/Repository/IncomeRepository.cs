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

    public async Task<bool> Create(Income income)
    {
        _context.Incomes.Add(income);
        return await Save();
    }

    public async Task<bool> Update(Income income)
    {
        _context.Incomes.Update(income);
        return await Save();
    }

    public async Task<bool> Delete(Income income)
    {
        _context.Incomes.Remove(income);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }
}