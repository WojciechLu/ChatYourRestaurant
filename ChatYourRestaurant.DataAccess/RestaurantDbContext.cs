using ChatYourRestaurant.DataAccess.Seeder;
using ChatYourRestaurant.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatYourRestaurant.DataAccess;

public class RestaurantDbContext: DbContext
{
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options): base(options)
    {
        
    }
        
    public DbSet<Order> Orders { get; set; }
    public DbSet<Meal> Meals { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
}
