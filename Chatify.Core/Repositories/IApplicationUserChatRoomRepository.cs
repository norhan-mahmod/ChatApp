using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Dtos.ChatDtos;
using Chatify.Core.Entities;

namespace Chatify.Core.Repositories
{
    public interface IApplicationUserChatRoomRepository : IGenericRepository<ApplicationUserChatRoom>
    {
        Task<List<UserChatRoomDto>> GetUserChatRoomsAsync(string userId);
    }
}
