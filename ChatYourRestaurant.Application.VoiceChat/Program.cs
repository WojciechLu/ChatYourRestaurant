using ChatYourRestaurant.Application.ChatBot;
using ChatYourRestaurant.Application.ChatBot.Handler;
using ChatYourRestaurant.DataAccess;
using ChatYourRestaurant.DataAccess.Repositories;
using ChatYourRestaurant.Domain.Common.Settings;
using ChatYourRestaurant.Domain.Service.Interfaces;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatYourRestaurant.Application.VoiceChat;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true);
        
        var config = builder.Build();
        
        var services = new ServiceCollection();
        services.AddDbContext<RestaurantDbContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IMealRepository, MealRepository>();


        var speechApiConfig = config.GetSection("SpeechApiSettings").Get<SpeechApiSettings>();
        var languageSettings = config.GetSection("LanguageSettings").Get<LanguageSettings>();

        var speechConfig = SpeechConfig.FromSubscription(speechApiConfig.SpeechKey, speechApiConfig.SpeechRegion);
        speechConfig.SpeechRecognitionLanguage = "en-US";

        using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
        using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);
        var languageServiceClient = new LanguageServiceClient(languageSettings);
        
        var serviceProvider = services.BuildServiceProvider();
        var intentHandler = new IntentHandler(serviceProvider.GetService<IMealRepository>(), serviceProvider.GetService<IOrderService>());

        Console.WriteLine("Speak into your microphone.");

        using var speechSynthesizer = new SpeechSynthesizer(speechConfig);
        while (true)
        {
            var speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();
            switch (speechRecognitionResult.Reason)
            {
                case ResultReason.RecognizedSpeech:
                    Console.WriteLine($"[User] RECOGNIZED: Text=[{speechRecognitionResult.Text}]");
                    var conversationResult = await languageServiceClient.AnalyzeTextAsync(speechRecognitionResult.Text);
                    var text = intentHandler.ReturnResponseBasedOnConversationIntend(conversationResult);
                    var speechSynthesisResult =
                        await speechSynthesizer.SpeakTextAsync(
                            text);
                    OutputSpeechSynthesisResult(speechSynthesisResult, text);
                    break;
                case ResultReason.NoMatch:
                    Console.WriteLine("[User] NOMATCH: Speech could not be recognized.");
                    break;
                case ResultReason.Canceled:
                    var cancellation = CancellationDetails.FromResult(speechRecognitionResult);
                    Console.WriteLine($"[User] CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"[User] CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"[User] CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine("[User] CANCELED: Did you set the speech resource key and region values?");
                    }

                    break;
            }
        }
    }
    static void OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text)
    {
        switch (speechSynthesisResult.Reason)
        {
            case ResultReason.SynthesizingAudioCompleted:
                Console.WriteLine($"[ChatAssistant] Speech synthesized for text: [{text}]");
                break;
            case ResultReason.Canceled:
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(speechSynthesisResult);
                Console.WriteLine($"[ChatAssistant] CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Console.WriteLine($"[ChatAssistant] CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Console.WriteLine($"[ChatAssistant] CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                    Console.WriteLine($"[ChatAssistant] CANCELED: Did you set the speech resource key and region values?");
                }
                break;
        }
    }
}