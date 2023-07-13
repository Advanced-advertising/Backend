using ADvanced.Models;
namespace ADvanced.Dto;

public class BusinessWorkingTimeDto
{
    public int Id { get; set; }
    public List<Business> Businesses { get; set; }
    public string DayOfTheWeek { get; set; }
    public string OpeningTime { get; set; }
    public string ClotheTime { get; set; }
}