using ADvanced.Models;

namespace ADvanced.Dto;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Payment> Payments { get; set; }
    public List<Ad> Ads { get; set; }
}