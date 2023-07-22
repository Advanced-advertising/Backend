using ADvanced.Data.Interfaces;
using ADvanced.Models;

namespace ADvanced.Data.Repository;

public class PaymentRepository : IRepository<Payment>
{
    private readonly ApplicationContext _context;

    public PaymentRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Payment> GetItemList()
    {
        return _context.Payments.ToList();
    }

    public Payment GetItem(int id)
    {
        return _context.Payments.Where(c => c.Id == id).FirstOrDefault();
    }

    public async Task<bool> Create(Payment payment)
    {
        _context.Payments.Add(payment);
        return await Save();
    }

    public async Task<bool> Update(Payment payment)
    {
        _context.Payments.Update(payment);
        return await Save();
    }

    public async Task<bool> Delete(Payment payment)
    {
        _context.Payments.Remove(payment);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }
}