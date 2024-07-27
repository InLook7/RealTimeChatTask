using Azure.AI.TextAnalytics;

namespace RealTimeChatTask.BLL.Interfaces;

public interface ITextAnalyticsService
{
    Task<DocumentSentiment> AnalyzeSentimentAsync(string text);
}