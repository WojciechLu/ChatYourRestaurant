using ChatYourRestaurant.Domain.Common.Enums;
using ChatYourRestaurant.Domain.Common.Models;

namespace ChatYourRestaurant.DataAccess.Repositories;

public interface IOrderRepository
{
    Order MakeOrder(Order order);
}

public class OrderRepository(RestaurantDbContext context): IOrderRepository
{
    public Order MakeOrder(Order order)
    {
        context.Orders.Add(order);
        context.SaveChanges();
        return order;
    }
}