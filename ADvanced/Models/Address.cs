namespace ADvanced.Models;

public class Address
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Business Business { get; set; }
    public List<Screen> Screens { get; set; }
}