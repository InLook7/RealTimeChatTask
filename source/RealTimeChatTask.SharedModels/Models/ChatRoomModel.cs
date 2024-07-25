using System.Text.Json.Serialization;

namespace RealTimeChatTask.SharedModels.Models;

public class ChatRoomModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}