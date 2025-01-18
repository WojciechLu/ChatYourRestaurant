// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace ChatYourRestaurant.Application.ChatBot;

public class RecommendBot : ActivityHandler
{
    private readonly LanguageServiceClient _languageClient;

    public RecommendBot(LanguageServiceClient languageClient)
    {
        _languageClient = languageClient;
    }

    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
        var userInput = turnContext.Activity.Text;
        var activityId = turnContext.Activity.Id;
        var recipientId = turnContext.Activity.Recipient.Id;

        // Call Azure Language Service to analyze user input
        var response = await _languageClient.AnalyzeTextAsync(userInput, activityId, recipientId, "ChatYourRestaurant", "ChatYourRestautantDeployment");

        // Parse the result from the response
        // Here you would typically parse out DishName, Description, etc.
        var replyText = $"Echo: {response}";

        // Respond to the user with the analysis or a dish recommendation
        await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
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
}
