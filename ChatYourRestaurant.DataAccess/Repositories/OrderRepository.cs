using ChatYourRestaurant.Domain.Common.Enums;
using ChatYourRestaurant.Domain.Common.Models;

namespace ChatYourRestaurant.DataAccess.Repositories;

public interface IOrderRepository
{
    Order MakeOrder(List<MealQuantity> mealQuantities);
}

public class OrderRepository(RestaurantDbContext context): IOrderRepository
{
    public Order MakeOrder(List<MealQuantity> mealQuantities)
    {
        var order = new Order
        {
            Oder = default,
            MealQuantities = mealQuantities,
            Status = OrderStatus.InProgress
        };
        context.Orders.Add(order);
        context.SaveChanges();
        return order;
    }
}