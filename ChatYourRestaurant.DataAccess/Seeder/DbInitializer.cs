using System.Reflection;
using ChatYourRestaurant.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ChatYourRestaurant.DataAccess.Seeder;

public class DbInitializer
{
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "ChatYourRestaurant.DataAccess.seedData.json"; // Namespace + file name

        using (var stream = assembly.GetManifestResourceStream(resourceName))
        using (var reader = new StreamReader(stream))
        {
            var json = reader.ReadToEnd();
            var seedMeals = JsonConvert.DeserializeObject<List<Meal>>(json);
            _modelBuilder.Entity<Meal>().HasData(seedMeals.ToArray());
        }
    }
}