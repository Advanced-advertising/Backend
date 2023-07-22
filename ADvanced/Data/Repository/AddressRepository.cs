using ADvanced.Data.Interfaces;
using ADvanced.Models;

namespace ADvanced.Data.Repository;

public class AddressRepository : IRepository<Address>
{
    private readonly ApplicationContext _context;

    public AddressRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Address> GetItemList()
    {
        return _context.Addresses.ToList();
    }

    public Address GetItem(int id)
    {
        return _context.Addresses.Where(c => c.Id == id).FirstOrDefault();
    }

    public async Task<bool> Create(Address address)
    {
        _context.Addresses.Add(address);
        return await Save();
    }

    public async Task<bool> Update(Address address)
    {
        _context.Addresses.Update(address);
        return await Save();
    }

    public async Task<bool> Delete(Address address)
    {
        _context.Addresses.Remove(address);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }
}