using ChatYourRestaurant.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatYourRestaurant.UI.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class MealController(IMealService mealService) : ControllerBase
{
    
    [HttpGet]
    public IActionResult GetAllMeans()
    {
        return Ok(mealService.GetAll());
    }
}