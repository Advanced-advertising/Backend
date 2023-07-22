using ADvanced.Data.Interfaces;
using ADvanced.Models;

namespace ADvanced.Data.Repository;

public class CategoryRepository : IRepository<Category>
{
    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Category> GetItemList()
    {
        return _context.Categories.ToList();
    }

    public Category GetItem(int id)
    {
        return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
    }

    public async Task<bool> Create(Category category)
    {
        _context.Categories.Add(category);
        return await Save();
    }

    public async Task<bool> Update(Category category)
    {
        _context.Categories.Update(category);
        return await Save();
    }

    public async Task<bool> Delete(Category category)
    {
        _context.Categories.Remove(category);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }
}