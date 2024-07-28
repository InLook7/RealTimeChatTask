namespace RealTimeChatTask.BLL.DTOs;

public class SentimentDTO : BaseDTO
{
    public int MessageId { get; set; }
    public string SentimentResult { get; set; }
    public double PositiveScore { get; set; } 
    public double NeutralScore { get; set; } 
    public double NegativeScore { get; set; } 
}