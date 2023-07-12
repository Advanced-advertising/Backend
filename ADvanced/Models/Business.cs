namespace ADvanced.Models;

public class Business
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Img { get; set; }
    public List<Income> Incomes { get; set; }
    public List<Screen> Screens { get; set; }
    public List<Address> Addresses { get; set; }
    public List<Category> Categories { get; set; }
    public List<BusinessWorkingTime> BusinessWorkingTimes { get; set; }
}