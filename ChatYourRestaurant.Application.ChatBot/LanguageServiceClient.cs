using System.Net.Http.Json;
using System.Text;
using ChatYourRestaurant.Domain.Common.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ChatYourRestaurant.Application.ChatBot;

public class LanguageServiceClient
{
    private readonly LanguageSettings _languageSettings;

    public LanguageServiceClient(IOptions<LanguageSettings> languageSettings)
    {
        _languageSettings = languageSettings.Value;
    }
    public async Task<ConversationResult> AnalyzeTextAsync(string inputText, string activityId, string recipientId,
        string projectName,
        string deploymentName)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _languageSettings.ApiKey);
        client.DefaultRequestHeaders.Add("Apim-Request-Id", _languageSettings.ApimRequestId);

        var request = new
        {
            kind = "Conversation",
            parameters = new
            {
                projectName,
                deploymentName,
                verbose=true,
                stringIndexType = "TextElement_V8"
            },
            analysisInput = new
            {
                conversationItem = new {
                    id = activityId,
                    text = inputText,
                    modality = "text",
                    language = "en",
                    participantId = recipientId
                }
            }
        };

        var jsonRequest = JsonSerializer.Serialize(request);
        var response = await client.PostAsync(
            _languageSettings.Endpoint,
            new StringContent(jsonRequest, Encoding.UTF8, "application/json"));
        
        var responseMessage = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ConversationResult>();
    }
}
