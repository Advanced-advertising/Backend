namespace ADvanced.Models;

public class AdOrder
{
    public int Id { get; set; }
    public Ad Ad { get; set; }
    public Screen Screen { get; set; }
    public decimal Price { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public Status Status { get; set; } // 
    public Income Income { get; set; }
    public Payment Payment { get; set; }
}