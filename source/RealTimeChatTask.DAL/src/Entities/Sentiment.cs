namespace RealTimeChatTask.DAL.Entities;

public class Sentiment : BaseEntity
{
    public int MessageId { get; set; }
    public string SentimentResult { get; set; }
    public double PositiveScore { get; set; } 
    public double NeutralScore { get; set; } 
    public double NegativeScore { get; set; } 

    public Message Message { get; set; }
}