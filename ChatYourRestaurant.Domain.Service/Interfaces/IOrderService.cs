using ChatYourRestaurant.Domain.Common.Dtos;
using ChatYourRestaurant.Domain.Common.Models;

namespace ChatYourRestaurant.Domain.Service.Interfaces;

public interface IOrderService
{
    OrderDto MakeOrder(List<MealQuantityDto> mealQuantities);
}