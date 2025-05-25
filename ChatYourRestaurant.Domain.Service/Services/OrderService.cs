using System.Text.Json;
using System.Text.Json.Serialization;
using ChatYourRestaurant.DataAccess.Repositories;
using ChatYourRestaurant.Domain.Common.Dtos;
using ChatYourRestaurant.Domain.Common.Enums;
using ChatYourRestaurant.Domain.Common.Models;
using ChatYourRestaurant.Domain.Service.Interfaces;

namespace ChatYourRestaurant.Domain.Service.Services;

public class OrderService(IOrderRepository orderRepository, IMealRepository mealRepository): IOrderService
{
    public OrderDto MakeOrder(List<MealQuantityDto> mealQuantities)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            MealQuantities = new List<MealQuantity>(),
            Status = OrderStatus.InProgress
        };

        var meals = mealRepository.GetByIds(mealQuantities.Select(x => x.Id).ToList());
        var newMealQuantities = mealQuantities.Select(x =>
        {
            var meal = meals.First(meal => meal.Id == x.Id);
            return new MealQuantity
            {
                MealId = meal.Id,
                Meal = meal,
                OrderId = order.Id,
                Order = order,
                Quantity = x.Quantity,

            };
        }).ToList();
        
        order.MealQuantities = newMealQuantities;
        var savedOrder = orderRepository.MakeOrder(order);
        return savedOrder.ToDto();
    }
}