﻿namespace ChatYourRestaurant.Domain.Common.Models;

public class MealQuantity
{
    public required int MealId { get; set; }
    public required Meal Meal { get; set; }
    public required Guid OrderId { get; set; }
    public required Order Order { get; set; }
    public int Quantity { get; set; }

    public MealQuantityResultDto ToDto()
    {
        return new MealQuantityResultDto
        {
            MealId = MealId,
            OrderId = OrderId,
            Quantity = Quantity
        };
    }
}


public class MealQuantityResultDto
{
    public required int MealId { get; set; }
    public required Guid OrderId { get; set; }
    public int Quantity { get; set; }
}