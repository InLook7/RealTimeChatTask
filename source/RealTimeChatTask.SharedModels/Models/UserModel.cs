using System.Text.Json.Serialization;

namespace RealTimeChatTask.SharedModels.Models;

public class UserModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("userName")]
    public string UserName { get; set; }
}