using System.Security.Claims;
using Chatify.Core.Dtos.ChatDtos;
using Chatify.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IChatService chatService;
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public ChatController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        [HttpPost("CreateUserChat")]
        public async Task<IActionResult> CreateUserChat(string receiverUserId)
        {
            var result = await chatService.CreateUserChat(CurrentUserId, receiverUserId);
            if(!result.IsSucceeded)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("CreateGroupChatRoom")]
        public async Task<IActionResult> CreateGroupChatRoom([FromForm]CreateGroupChatRoomDto chatRoomDto)
        {
            var result = await chatService.CreateGroupChatRoom(CurrentUserId, chatRoomDto);
            if(!result.IsSucceeded)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("GetUserChats")]
        public async Task<IActionResult> GetUserChats()
        {
            var chatrooms = await chatService.GetUserChatRoomsWithDetailsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(chatrooms);
        }
    }
}
