using ADvanced.Models;

namespace ADvanced.Dto;

public class IncomeDto
{
    public int Id { get; set; }
    public AdOrder AdOrder { get; set; }
    public Business Business { get; set; }
    public decimal IncomeCount { get; set; }
}