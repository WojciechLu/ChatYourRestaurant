using ChatYourRestaurant.Domain.Common.Models;

namespace ChatYourRestaurant.Domain.Service.Interfaces;

public interface IMealService
{
    List<Meal> GetAll();
}