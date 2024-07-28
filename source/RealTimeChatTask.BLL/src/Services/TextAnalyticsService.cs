using Azure.AI.TextAnalytics;
using RealTimeChatTask.BLL.Interfaces;

namespace RealTimeChatTask.BLL.Services;

public class TextAnalyticsService : ITextAnalyticsService
{
    private readonly TextAnalyticsClient _textAnalyticsClient;

    public TextAnalyticsService(TextAnalyticsClient textAnalyticsClient)
    {
        _textAnalyticsClient = textAnalyticsClient;
    }

    public async Task<DocumentSentiment> AnalyzeSentimentAsync(string text)
    {
        var response = await _textAnalyticsClient.AnalyzeSentimentAsync(text);

        return response.Value;
    }
}