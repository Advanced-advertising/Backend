using ADvanced.Models;

namespace ADvanced.Data.Interfaces;

public interface IAdOrderRepository
{
    IEnumerable<AdOrder> GetAdOrderList();
    AdOrder GetAdOrder(int id);
    bool CreateAdOrder(AdOrder address);
    bool UpdateAdOrder(AdOrder address);
    bool DeleteAdOrder(AdOrder address);
    bool Save();
}