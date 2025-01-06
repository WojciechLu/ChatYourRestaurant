using System.ComponentModel.DataAnnotations;
using ChatYourRestaurant.Domain.Common.Enums;

namespace ChatYourRestaurant.Domain.Common.Models;

public class Order
{
    [Key]
    public Guid Id { get; set; }
    public required List<MealQuantity> MealQuantities { get; set; }
    public OrderStatus Status { get; set; }
}