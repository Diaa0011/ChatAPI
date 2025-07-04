using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs;

public class ChatHub : Hub
{
    private readonly IChatService _chatService;

    public ChatHub(IChatService chatService)
    {
        _chatService = chatService ?? throw new ArgumentNullException(nameof(chatService));
    }

    public async Task SendMessage(string sender, string roomName, string message)
    {
        // Broadcast to everyone in the room
        await Clients.Group(roomName).SendAsync(
            "ReceiveMessage",
            sender,
            message,
            DateTime.UtcNow
        );
    }

    public async Task MarkAsRead(string roomName, string messageId, string reader)
    {
        // Notify others in the room that this message was read
        await Clients.OthersInGroup(roomName).SendAsync(
            "MessageRead",
            messageId,
            reader,
            DateTime.UtcNow
        );
    }

    public async Task JoinRoom(string roomName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        await Clients.Group(roomName).SendAsync(
            "UserJoined",
            Context.User?.Identity?.Name ?? "Unknown"
        );
    }

    // 4. Optional: Leave a room
    public async Task LeaveRoom(string roomName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        await Clients.Group(roomName).SendAsync(
            "UserLeft",
            Context.User?.Identity?.Name ?? "Unknown"
        );
    }
}