using System;
using System.ComponentModel.DataAnnotations;
using ChatYourRestaurant.Domain.Common.Enums;

namespace ChatYourRestaurant.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid Oder { get; set; }
        public Meal Meal { get; set; }
        public OrderStatus Status { get; set; }
    }
}