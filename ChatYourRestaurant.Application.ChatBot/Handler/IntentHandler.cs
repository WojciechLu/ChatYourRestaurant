using ChatYourRestaurant.DataAccess.Repositories;

namespace ChatYourRestaurant.Application.ChatBot.Handler;

public class IntentHandler
{
    private readonly IMealRepository _mealRepository;

    public IntentHandler(IMealRepository mealRepository)
    {
        _mealRepository = mealRepository;
    }

    public string ReturnResponseBasedOnConversationIntend(ConversationResult response)
    {
        var replyText = response.Result.Prediction.TopIntent switch
        {
            "RecommendDish" => GetRecommendation(response.Result.Prediction.Entities.Select(x => x.Text)),
            "NotRecommandDish" => GetNotRecommendation(response.Result.Prediction.Entities.Select(x => x.Text)),
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

    private string Hello()
    {
        return
            "Hi, i am your chat assistant. Write me your favourite or not ingredients and I will recommend something ;)";
    }
}