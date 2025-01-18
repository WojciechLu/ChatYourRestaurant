namespace ChatYourRestaurant.Domain.Common.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Meal> UsedInMeals { get; set; } = new List<Meal>();
}