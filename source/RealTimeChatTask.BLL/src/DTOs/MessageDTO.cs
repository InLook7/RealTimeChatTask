namespace RealTimeChatTask.BLL.DTOs;

public class MessageDTO : BaseDTO
{
    public int ChatRoomId { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    public string Sentiment { get; set; }
}