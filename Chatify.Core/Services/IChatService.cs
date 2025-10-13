using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Dtos.ChatDtos;

namespace Chatify.Core.Services
{
    public interface IChatService
    {
        Task<List<ChatRoomDto>> GetUserChatRooms(string userId);
    }
}
