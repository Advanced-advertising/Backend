using ADvanced.Models;

namespace ADvanced.Dto;

public class ScreenDto
{
    public int Id { get; set; }
    public Business Business { get; set; }
    public Address Address { get; set; }
    public List<AdOrder> AdOrders { get; set; }
    public string Name { get; set; }
    public decimal PricePerTime { get; set; }
    public int Traffic { get; set; }
    public string Characteristics { get; set; }
}