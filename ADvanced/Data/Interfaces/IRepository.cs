namespace ADvanced.Data.Interfaces;

public interface IRepository<T> 
    where T : class
{
    IEnumerable<T> GetItemList();
    T GetItem(int id); 
    Task<bool> Create(T item); 
    Task<bool> Update(T item);
    Task<bool> Delete(T item); 
    Task<bool> Save(); 
}
