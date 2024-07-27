using System.Text.Json.Serialization;

namespace RealTimeChatTask.SharedModels.Models;

public class MessageModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("chatRoomId")]
    public int ChatRoomId { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("sentiment")]
    public string Sentiment { get; set; }

    [JsonPropertyName("userName")]
    public string UserName { get; set; }
}