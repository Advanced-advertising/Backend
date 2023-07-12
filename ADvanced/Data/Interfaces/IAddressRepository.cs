using ADvanced.Models;

namespace ADvanced.Data.Interfaces;

public interface IAddressRepository
{
    IEnumerable<Address> GetAddressList();
    Address GetAddress(int id);
    bool CreateAddress(Address address);
    bool UpdateAddress(Address address);
    bool DeleteAddress(Address address);
    bool Save();
}