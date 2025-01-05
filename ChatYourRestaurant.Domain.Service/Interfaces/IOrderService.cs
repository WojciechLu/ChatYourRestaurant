using ChatYourRestaurant.Domain.Common.Models;

namespace ChatYourRestaurant.Domain.Service.Interfaces;

public interface IOrderService
{
    Order MakeOrder(List<MealQuantity> mealQuantities);
}