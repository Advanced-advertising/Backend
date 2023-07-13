using ADvanced.Models;

namespace ADvanced.Dto;

public class AdDto
{
    public int Id { get; set; }
    public User User { get; set; } = new User();
    public string Name { get; set; } = "";
    public string Img { get; set; } = "";
    public Status Status { get; set; }  
    public List<Category> AdCategories { get; set; } = new List<Category>();
}