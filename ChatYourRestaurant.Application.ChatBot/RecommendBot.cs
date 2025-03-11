// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ChatYourRestaurant.DataAccess.Repositories;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace ChatYourRestaurant.Application.ChatBot;

public class RecommendBot : ActivityHandler
{
    private readonly LanguageServiceClient _languageClient;
    private readonly IMealRepository _mealRepository;

    public RecommendBot(LanguageServiceClient languageClient, IMealRepository mealRepository)
    {
        _languageClient = languageClient;
        _mealRepository = mealRepository;
    }

    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
        var userInput = turnContext.Activity.Text;
        var activityId = turnContext.Activity.Id;
        var recipientId = turnContext.Activity.Recipient.Id;

        // Call Azure Language Service to analyze user input
        var response = await _languageClient.AnalyzeTextAsync(userInput, activityId, recipientId, "ChatYourRestaurant", "ChatYourRestautantDeployment");

        var replyText = response.Result.Prediction.TopIntent switch
        {
            "RecommendDish" => GetRecommendation(response.Result.Prediction.Entities.Select(x => x.Text)),
            "NotRecommandDish" => GetNotRecommendation(response.Result.Prediction.Entities.Select(x => x.Text)),
            "None" or "Welcome" => Hello(),
            _ => string.Empty
        };
        // Parse the result from the response
        // Here you would typically parse out DishName, Description, etc.

        // Respond to the user with the analysis or a dish recommendation
        await turnContext.SendActivityAsync(MessageFactory.Text(replyText), cancellationToken);
    }

    // This method is called when a new member joins the conversation
    protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
    {
        var welcomeText = "Hello and welcome!";
        foreach (var member in membersAdded)
        {
            if (member.Id != turnContext.Activity.Recipient.Id)
            {
                await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
            }
        }
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
