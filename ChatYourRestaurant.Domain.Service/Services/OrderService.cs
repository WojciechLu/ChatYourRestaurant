using ChatYourRestaurant.DataAccess.Repositories;
using ChatYourRestaurant.Domain.Common.Models;
using ChatYourRestaurant.Domain.Service.Interfaces;

namespace ChatYourRestaurant.Domain.Service.Services;

public class OrderService(IOrderRepository orderRepository): IOrderService
{
    public Order MakeOrder(List<MealQuantity> mealQuantities)
    {
        return orderRepository.MakeOrder(mealQuantities);
    }
}