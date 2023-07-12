namespace ADvanced.Models;

public class BusinessWorkingTime
{
    public int Id { get; set; }
    public List<Business> Businesses { get; set; }
    public string DayOfTheWeek { get; set; }
    public string OpeningTime { get; set; }
    public string ClotheTime { get; set; }
}