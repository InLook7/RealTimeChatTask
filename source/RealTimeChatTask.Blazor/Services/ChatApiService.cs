using System.Text.Json;
using RealTimeChatTask.Blazor.Interfaces;
using RealTimeChatTask.SharedModels.Models;

namespace RealTimeChatTask.Blazor.Services;

public class ChatApiService : IChatApiService
{
    private readonly HttpClient _httpClient;

    public ChatApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ChatRoomModel>> GetAllRooms()
    {
        var respose = await _httpClient.GetAsync("api/chat");
        var result = await respose.Content.ReadAsStringAsync();

        var rooms = JsonSerializer.Deserialize<List<ChatRoomModel>>(result);

        return rooms;
    }

    public async Task<List<MessageModel>> GetMessagesByRoom(int roomId)
    {
        var respose = await _httpClient.GetAsync($"api/chat/{roomId}/messages");
        var result = await respose.Content.ReadAsStringAsync();

        var messages = JsonSerializer.Deserialize<List<MessageModel>>(result);

        return messages;
    }
}