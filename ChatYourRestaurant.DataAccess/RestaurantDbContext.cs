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
        modelBuilder.Entity<MealQuantity>()
            .HasOne(mq => mq.Meal)
            .WithMany()
            .HasForeignKey(mq => mq.MealId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MealQuantity>()
            .HasOne(mq => mq.Order)
            .WithMany(o => o.MealQuantities)
            .HasForeignKey(mq => mq.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<MealQuantity>()
            .HasKey(nameof(MealQuantity.MealId), nameof(MealQuantity.OrderId));
        
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
}
