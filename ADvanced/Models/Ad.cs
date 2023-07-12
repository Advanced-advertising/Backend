namespace ADvanced.Models;

public class Ad
{
    public int Id { get; set; }
    public User User { get; set; } = new User();
    public string Name { get; set; } = "";
    public string Img { get; set; } = "";
    public Status Status { get; set; }  //+enum
    public List<Category> AdCategories { get; set; } = new List<Category>();
}