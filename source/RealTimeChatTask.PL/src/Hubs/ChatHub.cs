using Microsoft.AspNetCore.SignalR;

namespace RealTimeChatTask.PL.Hubs;

public class ChatHub : Hub
{
    public async Task JoinChat(string group)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, group);
    }
    
    public async Task SendMessage(string group, string message)
    {
        await Clients.Group(group).SendAsync("ReceiveMessage", message);
    }
}