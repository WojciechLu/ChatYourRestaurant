using System.Reflection;
using ChatYourRestaurant.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ChatYourRestaurant.DataAccess.Seeder;

public static class DbInitializer
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Console.WriteLine("Start seeding");
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "ChatYourRestaurant.DataAccess.seedData.json"; // Namespace + file name

        using var stream = assembly.GetManifestResourceStream(resourceName);
        using (var reader = new StreamReader(stream))
        {
            var json = reader.ReadToEnd();
        
            // Console.WriteLine("Deserializing Meals");
            var seedMeals = JsonConvert.DeserializeObject<List<Meal>>(json);

            var ingredientMeals = seedMeals.SelectMany(meal => meal.Ingredients.Select(ingredient => new IngredientMeal
            {
                MealId = meal.Id,
                IngredientId = ingredient.Id
            }));

            var ingredients = seedMeals.SelectMany(meal => meal.Ingredients).DistinctBy(x => x.Id);
            
            // Console.WriteLine("Start ingredients seed");
            modelBuilder.Entity<Ingredient>().HasData(ingredients.ToArray());
            // Console.WriteLine("Succeed ingredients seed");
            
            // Console.WriteLine("Start meals seed");
            modelBuilder.Entity<Meal>().HasData(seedMeals.Select(meal => new Meal
            {
                Id = meal.Id,
                Name = meal.Name,
                Description = meal.Description,
                Price = meal.Price
            }));
            // Console.WriteLine("Succeed meals seed");
            
            // Console.WriteLine("Start ingredientMeals seed");
            modelBuilder.Entity<IngredientMeal>().HasData(ingredientMeals);
            // Console.WriteLine("Succeed ingredientMeals seed");
        }
    }
}