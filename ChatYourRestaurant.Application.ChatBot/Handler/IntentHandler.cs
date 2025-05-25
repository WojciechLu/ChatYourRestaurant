using ChatYourRestaurant.DataAccess.Repositories;
using ChatYourRestaurant.Domain.Service.Interfaces;

namespace ChatYourRestaurant.Application.ChatBot.Handler;

public class IntentHandler
{
    private readonly IMealRepository _mealRepository;
    private readonly IOrderService _orderService;

    public IntentHandler(IMealRepository mealRepository, IOrderService orderService)
    {
        _mealRepository = mealRepository;
        _orderService = orderService;
    }

    public string ReturnResponseBasedOnConversationIntend(ConversationResult response)
    {
        var replyText = response.Result.Prediction.TopIntent switch
        {
            "RecommendDish" => GetRecommendation(response.Result.Prediction.Entities.Select(x => x.Text)),
            "NotRecommandDish" => GetNotRecommendation(response.Result.Prediction.Entities.Select(x => x.Text)),
            "OrderDish" => OrderDish(response.Result.Prediction.Entities.Select(x => x.Text)),
            "None" or "Welcome" => Hello(),
            _ => string.Empty
        };
        return replyText;
    }

    private string GetRecommendation(IEnumerable<string> enumerable)
    {
        var meals = _mealRepository.GetMealsByIngredients(enumerable, new List<string>());
        return $"Then, I would recommend for you: {string.Join(", ", meals.Select(x => x.Name))}";
    }
    private string GetNotRecommendation(IEnumerable<string> enumerable)
    {
        var meals = _mealRepository.GetMealsByIngredients(new List<string>(), enumerable);
        return $"Then, I would recommend for you: {string.Join(", ", meals.Select(x => x.Name))}";
    }
    private string OrderDish(IEnumerable<string> enumerable)
    {
        var dishes = _mealRepository.GetMealsByText(enumerable);
        // _orderService.MakeOrder(dishes.ToDto());
        return $"Your order has been created. Anything else?";
    }
    private string Hello()
    {
        return
            "Hi, i am your chat assistant. Write me your favourite or not ingredients and I will recommend something ;)";
    }
}