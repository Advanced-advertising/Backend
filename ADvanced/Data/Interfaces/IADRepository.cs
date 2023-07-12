using ADvanced.Models;

namespace ADvanced.Data.Interfaces;

public interface IADRepository
{
    IEnumerable<Ad> GetAdList();
    Ad GetAd(int id);
    bool CreateAd(Ad ad);
    bool UpdateAd(Ad ad);
    bool DeleteAd(Ad ad);
    bool Save();
}