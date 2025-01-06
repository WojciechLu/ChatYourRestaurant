using ChatYourRestaurant.Domain.Common.Models;

namespace ChatYourRestaurant.DataAccess.Repositories;

public interface IMealRepository
{
    List<Meal> GetAll();
    List<Meal> GetByIds(List<int> ids);
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
}