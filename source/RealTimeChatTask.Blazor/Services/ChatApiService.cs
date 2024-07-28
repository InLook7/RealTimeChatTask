using System.Text;
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

    public async Task<UserModel> AddUser(UserModel userModel)
    {
        var json = JsonSerializer.Serialize(userModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var respose = await _httpClient.PostAsync($"api/user", content);
        var result = await respose.Content.ReadAsStringAsync();

        var user = JsonSerializer.Deserialize<UserModel>(result);

        return user;
    }

    public async Task<UserModel> UpdateUser(UserModel userModel)
    {
        var json = JsonSerializer.Serialize(userModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var respose = await _httpClient.PutAsync($"api/user", content);
        var result = await respose.Content.ReadAsStringAsync();

        var user = JsonSerializer.Deserialize<UserModel>(result);

        return user;
    }
}