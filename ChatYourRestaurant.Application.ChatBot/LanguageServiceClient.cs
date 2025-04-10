using System.Net.Http.Json;
using System.Text;
using ChatYourRestaurant.Domain.Common.Settings;
using Microsoft.Extensions.Options;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ChatYourRestaurant.Application.ChatBot;

public class LanguageServiceClient
{
    private readonly LanguageSettings _languageSettings;

    public LanguageServiceClient(IOptions<LanguageSettings> languageSettings)
    {
        _languageSettings = languageSettings.Value;
    }

    public LanguageServiceClient(LanguageSettings languageSettings)
    {
        _languageSettings = languageSettings;
    }
    

    public async Task<ConversationResult> AnalyzeTextAsync(string inputText)
    {
        var request = new
        {
            kind = "Conversation",
            parameters = new
            {
                projectName = _languageSettings.ProjectName,
                deploymentName = _languageSettings.DeploymentName,
                verbose=true,
                stringIndexType = "TextElement_V8"
            },
            analysisInput = new
            {
                conversationItem = new {
                    id = Guid.NewGuid().ToString(),
                    text = inputText,
                    modality = "text",
                    language = "en",
                    participantId = Guid.NewGuid().ToString()
                }
            }
        };

        return await SendLanguageRequest(request);
    }

    private async Task<ConversationResult> SendLanguageRequest(object request)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _languageSettings.ApiKey);
        client.DefaultRequestHeaders.Add("Apim-Request-Id", _languageSettings.ApimRequestId);
        var jsonRequest = JsonSerializer.Serialize(request);
        var response = await client.PostAsync(
            _languageSettings.Endpoint,
            new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

        var responseMessage = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ConversationResult>();
    }

    public async Task<ConversationResult> AnalyzeTextAsync(string inputText, string activityId, string recipientId)
    {
        var request = new
        {
            kind = "Conversation",
            parameters = new
            {
                projectName = _languageSettings.ProjectName,
                deploymentName = _languageSettings.DeploymentName,
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
        
        return await SendLanguageRequest(request);
    }
}
