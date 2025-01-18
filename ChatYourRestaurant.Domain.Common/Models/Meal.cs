namespace ChatYourRestaurant.Domain.Common.Models;

public class Meal
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public decimal Price { get; set; }
}