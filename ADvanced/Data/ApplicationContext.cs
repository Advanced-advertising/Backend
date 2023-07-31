using ADvanced.Models;
using Microsoft.EntityFrameworkCore;

namespace ADvanced.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Ad> Ads { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<AdOrder> AdOrders { get; set; }
    public DbSet<Business> Business { get; set; }
    public DbSet<BusinessWorkingTime> BusinessWorkingTimes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Screen> Screens { get; set; }
    public DbSet<User> Users { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureDeleted();
        //Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Military"},
            new Category { Id = 2, Name = "Shadow"},
            new Category { Id = 3, Name = "Bet"}
        );
        modelBuilder.Entity<Income>().HasData(
            new Income { Id = 1, IncomeCount = 15}
        );
    }
}