namespace RealTimeChatTask.DAL.Entities;

public class Message : BaseEntity
{
    public int ChatRoomId { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    
    public ChatRoom ChatRoom { get; set; }
    public Sentiment Sentiment { get; set; }
}