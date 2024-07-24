using Microsoft.AspNetCore.SignalR;

namespace RealTimeChatTask.PL.Hubs;

public class ChatHub : Hub
{
    public async Task JoinChat()
    {
    	await Groups.AddToGroupAsync(Context.ConnectionId, "test");
    }
}