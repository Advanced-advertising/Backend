namespace ADvanced.Models;

public class Ad
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Name { get; set; }
    public string Img { get; set; }
    public string Status { get; set; } //+enum
    public List<Category> AdCategories { get; set; }
}