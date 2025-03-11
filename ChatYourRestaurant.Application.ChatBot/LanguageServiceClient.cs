using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ChatYourRestaurant.Application.ChatBot;

public class LanguageServiceClient
{
    private readonly string _endpoint = "https://chatyourrestaurantlanguage.cognitiveservices.azure.com/language/:analyze-conversations?api-version=2024-11-15-preview";
    private readonly string _apiKey = "B0bsMytKQYeIvFv9e3VCFg9Xu58eZFXwEmQMbHtGinpQbAImNtbAJQQJ99BAACYeBjFXJ3w3AAAaACOG3DPG";
    private readonly string _apimRequestId = "4ffcac1c-b2fc-48ba-bd6d-b69d9942995a";

    // public LanguageServiceClient(string endpoint, string apiKey)
    // {
    //     _endpoint = endpoint;
    //     _apiKey = apiKey;
    // }

    public async Task<ConversationResult> AnalyzeTextAsync(string inputText, string activityId, string recipientId,
        string projectName,
        string deploymentName)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);
        client.DefaultRequestHeaders.Add("Apim-Request-Id", _apimRequestId);

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
            _endpoint,
            new StringContent(jsonRequest, Encoding.UTF8, "application/json"));
        
        var responseMessage = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ConversationResult>();
    }
}
