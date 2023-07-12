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
        Database.Migrate();
    }
}