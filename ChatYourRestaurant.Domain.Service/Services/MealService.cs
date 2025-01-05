using ChatYourRestaurant.DataAccess.Repositories;
using ChatYourRestaurant.Domain.Common.Models;
using ChatYourRestaurant.Domain.Service.Interfaces;

namespace ChatYourRestaurant.Domain.Service.Services;

public class MealService(IMealRepository repository): IMealService
{
    public List<Meal> GetAll()
    {
        return repository.GetAll();
    }
}