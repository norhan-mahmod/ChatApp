using System.Security.Claims;
using Chatify.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chatify.API.Chat
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IChatService chatService;

        private string UserId => Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        public ChatHub(IChatService chatService)
        {
            this.chatService = chatService;
        }

        public override async Task OnConnectedAsync()
        {
            // Join Personal Group
            await Groups.AddToGroupAsync(Context.ConnectionId, UserId);

            // Join All ChatRooms That User belongs to
            var chatrooms = await chatService.GetUserChatRooms(UserId);
            foreach (var chatroom in chatrooms)
                await Groups.AddToGroupAsync(Context.ConnectionId, $"{chatroom.Name}-{chatroom.Id}");

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Remove User From Personal Group
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, UserId);

            // Remove User From ChatRooms that he belongs to
            var chatrooms = await chatService.GetUserChatRooms(UserId);
            foreach (var chatroom in chatrooms)
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"{chatroom.Name}-{chatroom.Id}");

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageToUser(string receiverId , string message)
        {

        }
    }
}
