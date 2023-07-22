namespace ADvanced.Models;

public class Screen
{
    public int Id { get; set; }
    //public List<Business> Business { get; set; } // 1 to 1
    //public List<Address> Address { get; set; } // 1 to 1
    public List<AdOrder> AdOrders { get; set; }
    public string Name { get; set; }
    public decimal PricePerTime { get; set; }
    public int Traffic { get; set; }
    public string Characteristics { get; set; }
}