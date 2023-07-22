using ADvanced.Models;

namespace ADvanced.Data.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> GetItemList();
    Category GetItem(int id); 
    Task<bool> Create(Category item); 
    Task<bool> Update(Category item);
    Task<bool> Delete(Category item);
    Task<bool> Save();
}