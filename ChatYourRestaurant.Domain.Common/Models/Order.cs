using System.ComponentModel.DataAnnotations;
using ChatYourRestaurant.Domain.Common.Enums;

namespace ChatYourRestaurant.Domain.Common.Models;

public class Order
{
    [Key]
    public Guid Id { get; set; }
    public required List<MealQuantity> MealQuantities { get; set; }
    public OrderStatus Status { get; set; }

    public OrderDto ToDto()
    {
        return new OrderDto
        {
            Id = Id,
            Status = OrderStatus.InProgress,
            MealQuantityDtos = MealQuantities.Select(x => x.ToDto())
        };
    }
}

public class OrderDto
{
    public Guid Id { get; set; }
    public OrderStatus Status { get; set; }
    public IEnumerable<MealQuantityResultDto> MealQuantityDtos { get; set; }
}