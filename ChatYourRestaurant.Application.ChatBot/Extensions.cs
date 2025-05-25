using ChatYourRestaurant.Application.ChatBot.Handler;
using ChatYourRestaurant.Domain.Common.Settings;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace ChatYourRestaurant.Application.ChatBot;

public static class Extensions
{
    public static IServiceCollection SetUpBotModule(this IServiceCollection services)
    {
        // Create the Bot Framework Authentication to be used with the Bot Adapter.
        services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();
        
        // Create the Bot Adapter with error handling enabled.
        services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();
        
        // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
        services.AddTransient<IntentHandler>();
        services.AddTransient<LanguageServiceClient>();
        services.AddTransient<IBot, RecommendBot>();
        
        return services;
    }
}