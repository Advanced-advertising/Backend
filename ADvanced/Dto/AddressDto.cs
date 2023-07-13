using ADvanced.Models;

namespace ADvanced.Dto;

public class AddressDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Business Business { get; set; }
    public List<Screen> Screens { get; set; }
}