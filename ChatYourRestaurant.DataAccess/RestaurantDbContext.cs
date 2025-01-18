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
    public required DbSet<Ingredient> Ingredients { get; set; }
    public required DbSet<IngredientMeal> IngredientMeals { get; set; }
    

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

        modelBuilder.Entity<Meal>()
            .HasMany(m => m.Ingredients)
            .WithMany(i => i.UsedInMeals)
            .UsingEntity<IngredientMeal>(
                j => j.HasOne<Ingredient>().WithMany().HasForeignKey(x => x.IngredientId),
                j => j.HasOne<Meal>().WithMany().HasForeignKey(x => x.MealId),
                j =>
                {
                    j.HasKey(x => new { x.IngredientId, x.MealId });
                    j.ToTable("IngredientMeal");
                });
        
        base.OnModelCreating(modelBuilder);
        DbInitializer.Seed(modelBuilder);
    }
}
