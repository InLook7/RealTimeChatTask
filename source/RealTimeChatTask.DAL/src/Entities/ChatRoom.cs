namespace RealTimeChatTask.DAL.Entities;

public class ChatRoom : BaseEntity
{
	public string Name { get; set; }
	
	public IEnumerable<Message> Messages { get; set; }
}