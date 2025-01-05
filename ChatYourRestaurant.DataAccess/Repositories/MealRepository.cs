using ChatYourRestaurant.Domain.Common.Models;

namespace ChatYourRestaurant.DataAccess.Repositories;

public interface IMealRepository
{
    List<Meal> GetAll();
}

public class MealRepository(RestaurantDbContext context): IMealRepository
{
    public List<Meal> GetAll()
    {
        return context.Meals.ToList();
    }
}