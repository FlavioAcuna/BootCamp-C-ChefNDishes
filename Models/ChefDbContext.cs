using Microsoft.EntityFrameworkCore;

namespace ChefNDishes.Models;
public class ChefDbContext : DbContext
{
    public ChefDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Chef> chefs { get; set; }
    public DbSet<Dish> dishes { get; set; }
}