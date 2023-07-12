namespace ADvanced.Data.Interfaces;

public interface IRepository<T> 
    where T : class
{
    IEnumerable<T> GetItemList();
    T GetItem(int id); 
    bool Create(T item); 
    bool Update(T item);
    bool Delete(T item); 
    bool Save(); 
}
