namespace RealTimeChatTask.DAL.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }

    public IEnumerable<Message> Messages { get; set; }
}