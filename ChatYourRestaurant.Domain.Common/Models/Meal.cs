namespace ChatYourRestaurant.Domain.Common.Models;

public class Meal
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
}