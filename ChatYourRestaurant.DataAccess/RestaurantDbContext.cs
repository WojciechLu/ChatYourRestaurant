using ChatYourRestaurant.DataAccess.Seeder;
using ChatYourRestaurant.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatYourRestaurant.DataAccess;

public class RestaurantDbContext: DbContext
{
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options): base(options)
    {
        
    }
        
    public required DbSet<Order> Orders { get; set; }
    public required DbSet<Meal> Meals { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
}
