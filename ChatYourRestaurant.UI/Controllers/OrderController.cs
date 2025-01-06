using ChatYourRestaurant.Domain.Common.Dtos;
using ChatYourRestaurant.Domain.Common.Models;
using ChatYourRestaurant.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatYourRestaurant.UI.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class OrderController(IOrderService orderService) : ControllerBase
{
    
    [HttpPost]
    public IActionResult MakeOrder(List<MealQuantityDto> mealQuantities)
    {
        return Ok(orderService.MakeOrder(mealQuantities));
    }
}