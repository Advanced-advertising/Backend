namespace ADvanced.Models;

public class Payment
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public User User { get; set; }
    //public AdOrder AdOrder { get; set; }
}