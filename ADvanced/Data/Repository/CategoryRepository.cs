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

    public bool Create(Category category)
    {
        _context.Categories.Add(category);
        return Save();
    }

    public bool Update(Category category)
    {
        _context.Categories.Update(category);
        return Save();
    }

    public bool Delete(Category category)
    {
        _context.Categories.Remove(category);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}