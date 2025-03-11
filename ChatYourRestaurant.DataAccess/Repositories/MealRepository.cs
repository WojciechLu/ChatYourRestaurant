using ChatYourRestaurant.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatYourRestaurant.DataAccess.Repositories;

public interface IMealRepository
{
    List<Meal> GetAll();
    List<Meal> GetByIds(List<int> ids);
    List<Meal> GetMealsByIngredients(IEnumerable<string> ingredients, IEnumerable<string> excludeIngredients);
}

public class MealRepository(RestaurantDbContext context): IMealRepository
{
    public List<Meal> GetAll()
    {
        return context.Meals.ToList();
    }

    public List<Meal> GetByIds(List<int> ids)
    {
        return context.Meals.Where(x => ids.Contains(x.Id)).ToList();
    }

    public List<Meal> GetMealsByIngredients(IEnumerable<string> ingredients, IEnumerable<string> excludeIngredients)
    {
        var meals = context.Meals.Include(x => x.Ingredients).ToList();
        if (ingredients.Any())
        {
            meals = meals.Where(x => ingredients.All(lookingFor => x.Ingredients.Select(ingredient => ingredient.Name)
                .Any(ingredientName => string.Equals(ingredientName, lookingFor,
                    StringComparison.InvariantCultureIgnoreCase)))
            ).ToList();
        }

        if (excludeIngredients.Any())
        {
            meals = meals.Where(x => excludeIngredients.All(lookingFor => x.Ingredients.Select(ingredient => ingredient.Name)
                .All(ingredientName => !string.Equals(ingredientName, lookingFor,
                    StringComparison.InvariantCultureIgnoreCase)))).ToList();
        }
        return meals.Take(5).ToList();
    }
}